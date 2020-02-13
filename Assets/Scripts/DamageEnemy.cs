using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : MonoBehaviour
{
    public int damage=1;
    [SerializeField]UnityEvent OnDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable!= null)
        {
            damageable.TakeDamage(damage);
            OnDamage?.Invoke();
        }
    }
}
