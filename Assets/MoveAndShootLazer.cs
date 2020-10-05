using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndShootLazer : MonoBehaviour
{ 
    public float speed=0.3f;
    public float laserTime = 2f;
    public float waitTime = 2f;
    public GameObject lazer;
    Player player;
    Rigidbody2D body;

    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameManager.instance.player;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        lazer.SetActive(false);
        body.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        lazer.SetActive(true);
        AudioManager.instance.Play("Laser");
        StartMoving();
        yield return new WaitForSeconds(laserTime);
        StartCoroutine(Wait());
    }

    
 
    private void StartMoving()
    {
       
        if(player.transform.position.x > transform.position.x)
        {
            body.velocity = Vector2.right*speed;
        }
        else
        {
             body.velocity = Vector2.left*speed;
        }
        
    }

}
