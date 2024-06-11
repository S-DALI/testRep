using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseCell : MonoBehaviour
{
    public List<Cell> cells = new List<Cell>();
}

[System.Serializable]
public class Cell
{
    public int id;
    public string name;
    public GameObject cell;
}