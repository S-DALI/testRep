using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Mine mine;
    private Vector3 touchStartPosition;
    private Vector3 objectStartPosition;
    private bool isDragging = false;

    void Update()
    {
        // Проверяем сенсорные свайпы
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && IsTouchingObject(touch.position))
            {
                touchStartPosition = Camera.main.ScreenToWorldPoint(touch.position);
                objectStartPosition = transform.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 touchCurrentPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 deltaPosition = touchCurrentPosition - touchStartPosition;
                transform.position = objectStartPosition + deltaPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
        // Проверяем перетаскивание мышкой
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (isDragging)
            {
                transform.position = objectStartPosition + (mousePosition - touchStartPosition);
            }
            else if (IsTouchingObject(Input.mousePosition))
            {
                mine.GivenResorce();
                touchStartPosition = mousePosition;
                objectStartPosition = transform.position;
                isDragging = true;
            }
        }
        else
        {
            isDragging = false;
        }
    }

    private bool IsTouchingObject(Vector3 touchPosition)
    {
        Collider2D collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touchPosition));
        return collider != null && collider.gameObject == gameObject && collider.gameObject.CompareTag("Mine");
    }
}