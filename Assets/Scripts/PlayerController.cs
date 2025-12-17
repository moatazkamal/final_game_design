<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
=======
>>>>>>> 8dcdb75 (Add updated Unity project files)
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
<<<<<<< HEAD
    float touchXDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitX;

    private Animator animator;
    private bool isRunning = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        SetRunning(false);
    }

    [System.Obsolete]
    void Update()
    {
        SwipeCheck();
    }

    [System.Obsolete]
=======
    public float xSpeed;
    public float limitX;

    [Header("Jump")]
    public float jumpForce = 6f;
    public bool isGrounded = true;

    float touchXDelta = 0;
    float newX = 0;

    private Animator animator;
    private Rigidbody rb;
    private bool isRunning = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        SetRunning(false);

        // Prevent physics from rotating the player
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        SwipeCheck();

        // JUMP
        if (isRunning && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

>>>>>>> 8dcdb75 (Add updated Unity project files)
    private void SwipeCheck()
    {
        if (!isRunning)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                GameManager.instance.StartGame();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.StartGame();
            }
        }

        if (isRunning)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }
            else if (Input.GetMouseButton(0))
            {
                touchXDelta = Input.GetAxis("Mouse X");
            }
            else
            {
                touchXDelta = 0;
            }
<<<<<<< HEAD
            newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);

            Vector3 newPosition = new(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
=======

            newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);

            float newY = Mathf.Max(transform.position.y, 0f);

            Vector3 newPosition = new Vector3(
                newX,
                newY,
                transform.position.z + runningSpeed * Time.deltaTime
            );

>>>>>>> 8dcdb75 (Add updated Unity project files)
            transform.position = newPosition;
        }
    }

<<<<<<< HEAD
=======
    private void OnCollisionEnter(Collision collision)
    {
        // Simple ground check
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

>>>>>>> 8dcdb75 (Add updated Unity project files)
    public void StartRunning()
    {
        isRunning = true;
        SetRunning(true);
    }
<<<<<<< HEAD
=======

>>>>>>> 8dcdb75 (Add updated Unity project files)
    void SetRunning(bool running)
    {
        if (animator != null)
        {
            animator.SetBool("Running", running);
        }
    }
}
