using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerStats :Stats
{
    public int maxHp;
    public int coins;
    public int dmg;
    public float fireRate;
    public FireType fireType;
    public UnityEventInt OnLifeChange;
    public UnityEventInt OnMoneyChange; 
    public void ChangeHealth(int delta)
    {
        if(delta < 0)
        {
            AudioManager.instance.Play("Hit");
        }
        hp+=delta;
        if(hp>maxHp)hp=maxHp;
        OnLifeChange?.Invoke(hp);
    }
    public bool CanBuy(int price) => coins - price >=0;
    public void Buy(int price)
    {
        coins-=price;
        OnMoneyChange?.Invoke(coins);
    }
    
}
[System.Serializable]
public enum FireType
{
    Single,
    Double,
    Triple
}
