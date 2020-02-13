using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public Sprite icon;
    public  int price;
    public bool bought;
    public GameObject bullet;
    [HideInInspector]public ShotingHandler shotingHandler;
    public float timeSpeed=0;
    public abstract void ShootMethod();
}
