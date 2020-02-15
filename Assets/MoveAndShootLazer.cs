using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndShootLazer : MonoBehaviour
{ 
    public float speed=0.3f;
    public float startTime = 2f;
    public GameObject lazer;
    Player player;
    Rigidbody2D body;
    float timeBtwLazer;
    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameManager.instance.player;
        timeBtwLazer = startTime;
    }

    // Update is called once per frame
    void Update()
    {

        timeBtwLazer -= Time.deltaTime;
        if (timeBtwLazer <= 0)
        {
            isMoving = !isMoving;
            timeBtwLazer = startTime;
            if(isMoving)AudioManager.instance.Play("Laser");
        }
        if (isMoving)
        {
            MoveAndLazer();
        }
        else
        {
            body.velocity=Vector2.zero;
            lazer.SetActive(false);
        }
    }

    private void MoveAndLazer()
    {
        lazer.SetActive(true);
        if(Mathf.Abs(player.transform.position.x - transform.position.x) < 0.1f)
        {
            body.velocity=Vector2.zero;
        }else if(player.transform.position.x > transform.position.x)
        {
            body.velocity = Vector2.right*speed;
        }
        else
        {
             body.velocity = Vector2.left*speed;
        }
        
    }
}
