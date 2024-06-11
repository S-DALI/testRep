using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int resourceGive;
    [SerializeField] private Resources collectorResources;
    public void GivenResorce()
    {
        collectorResources.StoneUpdate(resourceGive);
    }
}
