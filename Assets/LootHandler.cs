using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHandler : MonoBehaviour
{
    public GameObject[] coins;
    public GameObject powerUp;
    
    public void Roll()
    {
        int rand = Random.Range(0,100);
        if(rand < 12)
        {
            if (rand < 6)
            {
                Instantiate(coins[0],transform.position,coins[2].transform.rotation);
            }else if(rand< 10)
            {
                Instantiate(coins[1],transform.position,coins[2].transform.rotation);
            }
            else
            {
                Instantiate(coins[2],transform.position,coins[2].transform.rotation);
            }
            
        }
        if(rand > 95)
        {
            Instantiate(powerUp,transform.position,powerUp.transform.rotation);
        }
    }
}
