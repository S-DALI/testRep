using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int armor = 5;
    [SerializeField] private int upArmor = 10;
    private int currentHP;
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= (damage-armor);
        if(currentHP <= 0 )
        {
            Die();
        }
    }

    public void UpgrateArmor()
    {
        armor += upArmor;
        //индикация хода
    }

    public void ReturnArmor()
    {
        armor -= upArmor;
        //отключение индикация хода
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }
}
