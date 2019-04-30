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
        }
        if (isMoving)
        {
            MoveAndLazer();
        }
        else
        {
            lazer.SetActive(false);
        }
    }

    private void MoveAndLazer()
    {
        lazer.SetActive(true);
        transform.position = new Vector3(Vector3.MoveTowards(transform.position, player.transform.position, speed).x, transform.position.y, 0);
    }
}
