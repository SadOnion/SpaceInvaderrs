using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Image image;
    float time;
    [SerializeField]float timePerLevel=12;
    public UnityEvent OnJourneyEnd;
    public UnityEvent OnBoss;
    // Update is called once per frame
    void Update()
    {
        Progres();
    }
    private void Progres()
    {
        time+=Time.deltaTime;
        image.fillAmount = time/timePerLevel;
        if (time >= timePerLevel)
        {
            if(GameManager.instance.level % 3 == 0)
            {
                OnBoss?.Invoke();
            }
            else
            {
                OnJourneyEnd?.Invoke();
            }
            this.enabled=false;
            
        }
    }
    public void ResetBar()
    {
        time=0;
        this.enabled=true;
    }
}
