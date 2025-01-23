using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    float rotationSpeed = 100f; // Speed of rotation.

    private void Update()
    {
        // Check if there is at least one touch.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is in the "Move" phase.
            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the rotation amount based on touch movement.
                float x = touch.deltaPosition.x * rotationSpeed * Mathf.Deg2Rad;

                // Apply rotation to the object around the Y-axis (up).
                transform.Rotate(Vector3.up, x);
            }
        }
    }
}

