using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.up * speed;
    }
    public void SetVelocity(Vector2 vel)
    {
        body.velocity = vel*speed;
    }
}
