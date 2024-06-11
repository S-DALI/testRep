using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellValidator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Вырубки 
        if(other.CompareTag("Player") && gameObject.CompareTag("Forest"))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
