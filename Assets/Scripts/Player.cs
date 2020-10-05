using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour,IDamageable
{
    
    public PlayerStats stats;
    private PlayerMovement movement;
    [SerializeField]UnityEvent OnHit;
    bool invincible;
    private int healthPrice = 50;
  
    public void TakeDamage(int amount)
    {
        if (!invincible)
        {
        stats.ChangeHealth(-amount);
        if (stats.hp <= 0) GameManager.instance.GameOver();
            OnHit?.Invoke();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = new PlayerMovement(this);
    }

    // Update is called once per frame
    void Update()
    {
        movement.HandleMovementInput();
    }
    public void Invincible()  => invincible=true;
    public void StopInvincible()  => invincible=false;
    public void FireRateUp()=>stats.fireRate*=.7f;
    public void DmgUp()=>stats.dmg++;
    public void FireTypeUp()=>stats.fireType++;

    public void Heal()
    {
        if (stats.CanBuy(healthPrice) && stats.hp < stats.maxHp)
        {
            stats.Buy(healthPrice);
            stats.ChangeHealth(1);
        }
    }
    public void HealAll()
    {
        stats.ChangeHealth(stats.maxHp);
    }
}
[System.Serializable]
public class UnityEventInt:UnityEvent<int>{}