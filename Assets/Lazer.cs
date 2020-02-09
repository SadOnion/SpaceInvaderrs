using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable d = collision.GetComponent<IDamageable>();
        if (d != null)
        {
            d.TakeDamage(1);
        }
    }
}
