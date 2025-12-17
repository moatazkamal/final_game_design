using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class jump : MonoBehaviour
{
    public float forceAmount = 5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }
    }

    void LateUpdate()
    {
        // OVERRIDE Y after all Update() calls (including PlayerController)
        Vector3 pos = transform.position;

        if (pos.y < 0f)
            pos.y = 0f;

        transform.position = pos;
    }
}
