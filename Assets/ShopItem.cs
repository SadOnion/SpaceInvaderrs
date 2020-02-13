using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI price;
    [SerializeField]Image icon;
    [Space]
    [SerializeField]Item item;
    Player player;
    ShotingHandler shotingHandler;
    private void Start()
    {
        price.text=item.price.ToString();
        icon.sprite = item.icon;
        player = GameManager.instance.player;
        shotingHandler = player.gameObject.GetComponent<ShotingHandler>();
        item.shotingHandler=shotingHandler;
    }
    public void Click()
    {
        
             if (player.stats.CanBuy(item.price))
             {
                player.stats.Buy(item.price);
               
                shotingHandler.ChangeShoot(item.ShootMethod,item.bullet,item.timeSpeed);
             }
        
       
    }
}
