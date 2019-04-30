using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable!= null)
        {
            damageable.TakeDamage(GameManager.instance.player.stats.dmg);
            Destroy(gameObject);
        }
    }
}
