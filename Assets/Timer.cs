using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float time=1f;
    [SerializeField]UnityEvent OnTimerEnd;

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;
        if (time <= 0)
        {
            OnTimerEnd?.Invoke();
            Destroy(this);
        }
    }
}
