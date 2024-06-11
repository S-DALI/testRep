using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestClickButton : MonoBehaviour
{
    [SerializeField] private GameObject testGO;
    [SerializeField] private Text testText;
    private int coin = 0;
    public void TestClick()
    {
        testGO.SetActive(false);
        testText.text = coin.ToString();
        coin++;
    }
}
