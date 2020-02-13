using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    public Image[] lifes;

    public void UpdateLifes(int life)
    {
        foreach (var item in lifes)
        {
            item.enabled=false;
        }
        int hp = lifes.Length-life;
        for (int i = 0; i < lifes.Length-hp; i++)
        {
            lifes[i].enabled = true;
        }
    }
}
