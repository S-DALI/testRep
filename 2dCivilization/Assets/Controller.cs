using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] List<NPC> nPCs = new List<NPC>();
    [SerializeField] private GameObject map;
    private Transform[] numCells;
    private int startRandomPos;

    void Start()
    {
        numCells = map.GetComponentsInChildren<Transform>();
        startRandomPos = Random.Range(0, numCells.Length-1);
        for (int i = 0; i < nPCs.Count; i++)
        {
            nPCs[i].transform.position = new Vector3(numCells[startRandomPos].position.x, numCells[startRandomPos].position.y, numCells[startRandomPos].position.z);
        }
    }

    public void ResetWalk()
    {
        //ходы ботов
        for(int i = 0; i < nPCs.Count; i++)
        {
            nPCs[i].SetWalkIndication(true);
        }
    }
}
