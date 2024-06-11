using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private HealthSystem healthSystem;
    [SerializeField] private float rangeAttack = 20f;
    [SerializeField] private int damage = 20;
    private GameObject enemy;
    private bool isWalk;
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    public void Move(Transform cellsTarget)
    {
        if (isWalk && enemy == null)
        {
            transform.Translate(cellsTarget.position);
            isWalk = false;
        }
        else
            if (enemy != null && enemy.GetComponent<HealthSystem>().GetCurrentHP() < damage)
        {
            Attack();
            transform.Translate(cellsTarget.position);
        }
        else
            if(enemy != null && enemy.GetComponent<HealthSystem>().GetCurrentHP() > damage)
        {
            Attack();
        }

    }

    public void Attack()
    {
        if(enemy != null && isWalk)
        {
            HealthSystem enemyHP = enemy.GetComponent<HealthSystem>();
            if(enemyHP != null)
            {
                enemyHP.TakeDamage(damage);
                isWalk = false;
            }
        }
    }

    public void SetEnemyObj(GameObject enemyChecked)
    {
         enemy = enemyChecked;
    }

    public void SetWalkIndication(bool indication)
    {
        isWalk = indication;
    }
}
