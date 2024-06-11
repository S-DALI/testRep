using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveNPCToPoint : MonoBehaviour
{
    private Transform targetPoint;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private LayerMask cellLayer;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0))
        {
            Debug.Log("Клик");
            Vector3 clickPosition = Input.mousePosition;
            if(Input.touchCount>0)
            {
                clickPosition = Input.GetTouch(0).position;
            }
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero,100f, cellLayer);
            if(hit)
            {
                Debug.Log("Клетка");
                targetPoint = hit.transform;
                isMoving = true;
            }
            if(isMoving && targetPoint != null)
            {
                Debug.Log("Таргет");
                float speed = 5f;
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
                  if(transform.position == targetPoint.position )
                {
                isMoving = false;
                targetPoint = null;
                }
            }
        }  
    }
}
