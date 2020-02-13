using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour,IDamageable
{

    public Stats stats;
    protected Rigidbody2D body;
    [SerializeField]UnityEvent OnDie;
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
        OnDie?.Invoke();
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

 
}
