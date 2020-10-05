using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxValue;
    [SerializeField]Image bar;
    public int hp {get;private set; }
    
    private void Start()
    {
        hp = maxValue;
    }
    public int ChangeHealth(int delta)
    {
        hp+=delta;
        bar.fillAmount = (float)hp/maxValue;
        return hp;
    }
}
