using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public int startPrice;
    public int priceLinearGrowth;
    public int Price
    {
        get
        {
            return startPrice + level*priceLinearGrowth;
        }
    }
    public GameObject container;
    public RectTransform containerRect;
    public float padding =0.125f;
    public int maxUpgrade=4;
    private Container[] containers;
    public TextMeshProUGUI priceText;
    int level=0;
    PlayerStats stats;
    public UnityEvent OnUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        containers = new Container[maxUpgrade];
        DrawContainers();

        stats = FindObjectOfType<Player>().stats;
            UpdatePrice();
    }

   private void DrawContainers()
    {
        for (int i = 0; i < maxUpgrade; i++)
        {
            GameObject o = Instantiate(container,containerRect.transform.position+Vector3.right*padding*i,container.transform.rotation);
            o.transform.SetParent(transform);
            containers[i] = o.GetComponent<Container>();
        }
        containers[0].Fill();
    }
    public void NextUpgrade()
    {
        if (stats.CanBuy(Price) && level+1 < maxUpgrade)
        {

            stats.Buy(Price);
        level++;
        containers[level].Fill();
            OnUpgrade?.Invoke();
            UpdatePrice();
        }
    }
    public void UpdatePrice()
    {
        priceText.text = Price.ToString();
    }
}
