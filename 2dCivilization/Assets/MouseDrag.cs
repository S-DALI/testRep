using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 5f;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private float min = -5f;
    [SerializeField] private float max = 5f;

    private Vector3 startMousePosition;
    private Vector3 startPositionCamera;
    private Vector3 target;
    private bool isDragging = false;
    private float raycastDistance = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Drag(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, target, lerpSpeed * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        isDragging = false;
    }

    private void Drag(Vector3 mousePosition)
    {
        Vector3 mouseOffset = mousePosition - startMousePosition;

        float dragDistanceX = mouseOffset.x / Screen.width;
        float targetX = startPositionCamera.x + dragDistanceX * dragSpeed;
        targetX = Mathf.Clamp(targetX, min, max);

        float dragDistanceY = mouseOffset.y / Screen.height;
        float targetY = startPositionCamera.y + dragDistanceY * dragSpeed;
        targetY = Mathf.Clamp(targetY, min, max);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(targetX - transform.position.x, targetY - transform.position.y, 0), out hit, raycastDistance))
        {
            target = transform.position;
        }
        else
        {
            target = new Vector3(targetX, targetY, transform.position.z);
        }
    }

    private void StartDrag(Vector3 mousePosition)
    {
        startMousePosition = mousePosition;
        startPositionCamera = transform.position;
        isDragging = true;
    }
}
