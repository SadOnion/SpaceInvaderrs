using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField]UnityEvent OnDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable!= null)
        {
            int damage = GameManager.instance.player.stats.dmg;
            damageable.TakeDamage(damage);
            OnDamage?.Invoke();
        }
    }
}
