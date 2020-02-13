using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinText : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void UpdateText() =>text.text = GameManager.instance.player.stats.coins.ToString();
}
