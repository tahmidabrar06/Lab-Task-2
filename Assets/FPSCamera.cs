using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCamera : MonoBehaviour
{
    public float sensitivity;
    private Transform playerTransform;

    private float xRot;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();

        float mouseX = mouse.x * sensitivity * Time.deltaTime;
        float mouseY = mouse.y * sensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
