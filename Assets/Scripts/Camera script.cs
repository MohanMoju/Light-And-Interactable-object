using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    private float xRotation = 0f;
    public float sensitivity = 0.1f; // Adjust touch sensitivity
    public Transform playerBody; // Reference to the player body for horizontal rotation

    private Vector2 touchDelta; // Tracks the touch delta
    private bool isTouching; // Tracks whether the screen is being touched

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Get touch delta
                touchDelta = touch.deltaPosition;

                // Adjust rotation based on touch input
                float mouseX = touchDelta.x * sensitivity;
                float mouseY = touchDelta.y * sensitivity;

                // Vertical rotation (pitch)
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp to prevent over-rotation

                // Apply rotations
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX); // Rotate the player body for horizontal rotation
            }
        }
    }
}
