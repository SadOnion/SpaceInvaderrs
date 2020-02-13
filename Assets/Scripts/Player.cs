using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour,IDamageable
{
    
    public PlayerStats stats;
    private PlayerMovement movement;
    [SerializeField]UnityEvent OnHit;
    [SerializeField]UnityEventInt OnLifeChange;
    bool invincible;
    Rigidbody2D body;

  
    public void TakeDamage(int amount)
    {
        if (!invincible)
        {
        stats.hp -= amount;
        if (stats.hp <= 0) GameManager.instance.GameOver();
            OnHit?.Invoke();
            OnLifeChange?.Invoke(stats.hp);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        movement = new PlayerMovement(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.HandleMovementInput();
    }
    public void Invincible()  => invincible=true;
    public void StopInvincible()  => invincible=false;
}
[System.Serializable]
public class UnityEventInt:UnityEvent<int>{}