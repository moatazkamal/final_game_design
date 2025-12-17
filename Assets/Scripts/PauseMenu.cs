// PauseMenu.cs
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject pausePanel; // Drag PausePanel here

    [Header("Scenes")]
    public string mainMenuSceneName = "main menu"; // Must match EXACT scene name

    public static bool IsPaused { get; private set; }

    NavMeshAgent[] agents;

    void Start()
    {
        IsPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        // Cache agents (opponents)
        agents = FindObjectsOfType<NavMeshAgent>();

        // Make sure game starts unpaused
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    void Update()
    {
        // ESC -> Main Menu (works anytime)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMainMenu();
            return;
        }

        // P -> Pause/Resume
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        IsPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;

        // Stop NavMeshAgents (they can keep moving even if timeScale is 0)
        if (agents == null || agents.Length == 0)
            agents = FindObjectsOfType<NavMeshAgent>();

        foreach (var a in agents)
            if (a != null) a.isStopped = true;
    }

    public void Resume()
    {
        IsPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (agents == null || agents.Length == 0)
            agents = FindObjectsOfType<NavMeshAgent>();

        foreach (var a in agents)
            if (a != null) a.isStopped = false;
    }

    public void GoToMainMenu()
    {
        // Always reset pause state before loading menu
        IsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        // Optional: hide pause panel if it exists
        if (pausePanel != null)
            pausePanel.SetActive(false);

        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        // Reset time in case we quit from pause
        IsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        Application.Quit();
        Debug.Log("Game Quit");
    }
}
