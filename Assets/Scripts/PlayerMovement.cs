using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    Rigidbody2D body;
    Player playerToMove;
    // Start is called before the first frame update
    public PlayerMovement(Player player)
    {
        playerToMove = player;
        body = playerToMove.GetComponent<Rigidbody2D>();
    }
    public void HandleMovementInput()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(xAxis*playerToMove.stats.speed, body.velocity.y);
        body.transform.position = new Vector3(Mathf.Clamp(body.transform.position.x, -5.5f, 5.5f),body.transform.position.y,0);
    }
   
}
