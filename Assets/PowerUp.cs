using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null)
        {
            p.gameObject.GetComponent<ShotingHandler>().PowerUp();
            Destroy(gameObject);
        }
    }
}
