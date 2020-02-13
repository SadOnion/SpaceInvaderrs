using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]int maxValue;
    [SerializeField]Image bar;
    private int hp;
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
