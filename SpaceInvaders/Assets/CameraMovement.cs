using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float ofset;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,target.position.y+ofset,-10);
    }
}
