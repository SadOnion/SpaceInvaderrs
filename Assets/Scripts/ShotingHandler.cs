using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingHandler : MonoBehaviour
{
    public GameObject baseBullet;
    public float timeBtwShots=.75f;
    public float randomRange=1f;
    public bool randomShots;
    private float timer;
    public Transform[] spawnShot;
    Action shootMethod;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeBtwShots;
        shootMethod = BaseShootMethod;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            shootMethod();
            if (randomShots)
            {
                timer = UnityEngine.Random.Range(timeBtwShots-randomRange,timeBtwShots+randomRange);
            }
            else
            {
            timer = timeBtwShots;
            }
        }
    }
    
    
    private void BaseShootMethod()
    {
        GameObject o = Instantiate(baseBullet,spawnShot[0].position,baseBullet.transform.rotation);
         AudioManager.instance.Play("Enemy");
    }
  
}
