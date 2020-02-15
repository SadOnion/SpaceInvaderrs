using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public GameObject[] background;
    public float scrollSpeed;
    public float spriteHeight=40.96f;
    float distance;
    int index=0;
    // Update is called once per frame
    void LateUpdate()
    {
        distance+=Time.deltaTime*scrollSpeed;
        Vector3 posDelta =  Vector3.down*Time.deltaTime*scrollSpeed;
        background[0].transform.position+= posDelta;
        background[1].transform.position+= posDelta;
        if(distance >= spriteHeight)
        {
            background[index].transform.position += Vector3.up*2*spriteHeight;
            index = Next();
            distance=0;
        }
    }
    private int Next()
    {
        int returnInt= index + 1 == 2? 0:1;
        return returnInt;
    }
    
}
