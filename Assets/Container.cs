using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public Sprite fillSprite;
    public Sprite emptySprite;
    public bool flip;
    private Image image;
    public bool filled{ get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite=emptySprite;
    }

   public void Fill()
    {
        filled = true;
        image.sprite = fillSprite;
        if(flip){
            transform.eulerAngles = new Vector3(0,0,90);
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.y,rect.sizeDelta.x);
        }
    }
}
