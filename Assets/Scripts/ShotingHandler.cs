using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingHandler : MonoBehaviour
{
    public GameObject baseBullet;
    public float timeBtwShots=.75f;
    public bool randomShots;
    private float time;
    public Transform[] spawnShot;
    Action shootMethod;
    private bool boosted;
    [SerializeField]bool player=false;
    // Start is called before the first frame update
    void Start()
    {
        time = timeBtwShots;
        shootMethod = BaseShootMethod;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            shootMethod();
            if(player)AudioManager.instance.Play("Player");
            else AudioManager.instance.Play("Enemy");
            if (randomShots)
            {
                time = UnityEngine.Random.Range(timeBtwShots*2,timeBtwShots*4);
            }
            else
            {

            time = timeBtwShots;
            }
        }
    }
    private void ChangeShoot(Action method,GameObject projectile)
    {
        shootMethod = method;
        baseBullet = projectile;
    }
    public void ChangeShoot(Action method,GameObject projectile,float timeBtwShoots)
    {
        ChangeShoot(method,projectile);
        if (timeBtwShoots > 0)
        {

        this.timeBtwShots = timeBtwShoots;
        }
    }
    
    private void BaseShootMethod()
    {
        GameObject o = Instantiate(baseBullet,spawnShot[0].position,baseBullet.transform.rotation);
    }
    public void PowerUp()
    {
        StopAllCoroutines();
        if(boosted){
            timeBtwShots*=2f;
            boosted=false;
        }
        StartCoroutine(Boost());
        time=0;
    }
    private IEnumerator Boost()
    {
        boosted=true;
        float temp = timeBtwShots;
        timeBtwShots*=.5f;
        yield return new WaitForSeconds(10);
        boosted=false;
        timeBtwShots=temp;
    }
}
