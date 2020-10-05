using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinText : MonoBehaviour
{
    TextMeshProUGUI text;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        player = GameManager.instance.player;
        player.stats.OnMoneyChange.AddListener(UpdateText);
    }

    public void UpdateText(int money) =>text.text = money.ToString();
}
