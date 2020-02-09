using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("enter");
    }
    private void OnMouseExit()
    {
        Debug.Log("exit");
    }
    private void OnMouseDown()
    {
        Debug.Log("buy");
    }
}
