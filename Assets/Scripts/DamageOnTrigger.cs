using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{

    public int damage;
    public bool dontDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable d = collision.gameObject.GetComponent<IDamageable>();
        if (d != null)
        {
            d.TakeDamage(damage);
            if(dontDestroy) return;

            Destroy(gameObject);
        }
    }
}
