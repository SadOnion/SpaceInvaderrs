using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]int value=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if(p != null)
        {
            p.stats.coins+=value;
            Destroy(gameObject);
        }
    }
}
