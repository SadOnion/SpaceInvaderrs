﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    
    private readonly int ySpeed=10;
    Rigidbody2D body;
    Player playerToMove;
    // Start is called before the first frame update
    public PlayerMovement(Player player)
    {
        playerToMove = player;
        body = playerToMove.GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * ySpeed * Time
            .deltaTime;
    }
    public void HandleMovementInput()
    {
        
        float xAxis = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(xAxis*playerToMove.stats.speed*Time.deltaTime, body.velocity.y);
        body.transform.position = new Vector3(Mathf.Clamp(body.transform.position.x, -8, 8),body.transform.position.y,0);
    }

}
