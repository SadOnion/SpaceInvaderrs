using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{

    public Stats stats;
    protected Rigidbody2D body;

    public void TakeDamage(int amount)
    {
        
        stats.hp -= amount;
        if (stats.hp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

 
}
