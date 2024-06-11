using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingController : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 5f;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private float min = -5f;
    [SerializeField] private float max = 5f;


    private Vector2 startTouch;
    private Vector2 startPositionCamera;
    private Vector3 target;
    private bool isDragging = false;
    private float raycastDistance = 1f;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartDrag(touch);
                    break;
                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Drag(touch);
                        transform.position = Vector3.Lerp(transform.position, target, lerpSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    EndDrag(touch);
                    break;
            }
        }
    }

    private void EndDrag(Touch touch)
    {
        isDragging = false;
    }

    private void Drag(Touch touch)
    {
        Vector2 touchOffset = touch.position - startTouch;

        float dragDistanceX = touchOffset.x / Screen.width;
        float targetX = startPositionCamera.x + dragDistanceX * dragSpeed;
        targetX = Mathf.Clamp(targetX, min, max);

        float dragDistanceY = touchOffset.y / Screen.height;
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

    private void StartDrag(Touch touch)
    {
        startTouch = touch.position;
        startPositionCamera = transform.position;
        isDragging = true;
    }
}
