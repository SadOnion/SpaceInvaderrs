using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerStats :Stats
{
    public int maxHp;
    public int coins;
    public int dmg;
    
    public bool CanBuy(int price) => coins - price >=0;
    public void Buy(int price)=>coins-=price;
}
