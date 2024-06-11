using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] private int stone;
    [SerializeField] private Text stoneText;
    [SerializeField] private int wood;
    [SerializeField] private Text woodText;

    [Header("UI")]
    [SerializeField] private GameObject panelResources;
    void Start()
    {
        stone = PlayerPrefs.GetInt("Stone");
        stoneText.text = stone.ToString();
        panelResources.SetActive(false);
    }

    void Update()
    {
        stoneText.text = stone.ToString();
    }

    public void OpenResourcesPanel()
    {
        panelResources.SetActive(true);
    }
    public void CloseResourcesPanel()
    {
        panelResources.SetActive(false);
    }

    public void StoneUpdate(int number)
    {
        stone += number;
        PlayerPrefs.SetInt("Stone", stone);
    }
}
