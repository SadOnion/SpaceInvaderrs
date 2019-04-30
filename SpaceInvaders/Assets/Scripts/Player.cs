using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    
    public PlayerStats stats;
    private PlayerMovement movement;
  
    Rigidbody2D body;

  
    public void TakeDamage(int amount)
    {
        Debug.Log("hp" + stats.hp);
        stats.hp -= amount;
        if (stats.hp <= 0) GameManager.instance.GameOver();
        Debug.Log("hp"+stats.hp);
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
}
