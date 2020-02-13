using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BOSS : MonoBehaviour,IDamageable
{
   public Canon[] canons;
    public UnityEvent OnDie;
    public Health hp;
    int index=0;
    public void Shoot()
    {
        index = index+1>=2?0:1;
        canons[index].Shoot();
    }

    public void TakeDamage(int amount)
    {
        if (hp.ChangeHealth(-amount)<=0)
        {
            OnDie?.Invoke();
        }
    }
    public void PlayLaser() => AudioManager.instance.Play("Laser");
    
    public void StopLaser() => AudioManager.instance.StopPlaying("Laser");
}
