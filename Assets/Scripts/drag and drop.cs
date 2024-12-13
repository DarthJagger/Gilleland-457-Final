using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging = false;

    void Start()
    {
        // Cache the main camera
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // Calculate the offset between the object and the mouse position
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Update the object's position based on the mouse position and the offset
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        // Stop dragging the object
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the screen position to a world position
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z; // Maintain the object's Z position
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
