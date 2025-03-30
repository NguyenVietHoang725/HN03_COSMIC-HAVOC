using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private EnemyStats stats;

    private void Awake()
    {
        this.stats = GetComponent<EnemyStats>();
        this.rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        this.stats.health -= damage;
        Debug.Log(this.stats.health);

        if (stats.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy defeated!");
        Destroy(this.gameObject);
    }
}