using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    public Image[] lifes;
    private void Start()
    {
        Player player = GameManager.instance.player;
        player.stats.OnLifeChange.AddListener(UpdateLifes);
    }
    public void UpdateLifes(int life)
    {
        foreach (var item in lifes)
        {
            item.enabled=false;
        }
        
        for (int i = 0; i < life; i++)
        {
            lifes[i].enabled = true;
        }
    }
}
