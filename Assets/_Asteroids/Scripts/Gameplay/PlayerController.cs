using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [Space(20)]
    [Header("Settings")]
    [SerializeField] private float speedAngular = 120;
    [SerializeField] private float speedLinear = 4f;
    [SerializeField] private float impulse = 2f;
    [SerializeField] private float speedMax = 3.5f;

    private float inputV = 0f;
    private float inputH = 0f;

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        RotatePlayer();
        // MovePlayerTransform();
    }

    private void FixedUpdate()
    {
        MovePlayerRigidbody();
    }

    private void GetInput()
    {
        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");
    }

    private void RotatePlayer()
    {
        var rotation = inputH * Time.deltaTime * speedAngular;
        gameObject.transform.Rotate(Vector3.back, rotation, Space.Self);
    }

    private void MovePlayerTransform()
    {
        var translation = inputV * Time.deltaTime * speedLinear * Vector3.up;
        gameObject.transform.Translate(translation, Space.Self);
    }

    private void MovePlayerRigidbody()
    {
        if (inputV <= 0f) return;

        var direction = impulse * inputV * Time.deltaTime * transform.up;
        rb.AddForce(direction, ForceMode2D.Impulse);
    }
}
