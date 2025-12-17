using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Quit the game
    public void QuitGame()
    {
        Application.Quit();

        // This line is only useful inside the Unity Editor
        Debug.Log("Game Quit");
    }

    // Load SampleScene
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
