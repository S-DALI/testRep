using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    [SerializeField] private string tagObject;
    [SerializeField] private NPC npc;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(tagObject))
        {
            npc.SetEnemyObj(collision.gameObject);
        }
    }
}
