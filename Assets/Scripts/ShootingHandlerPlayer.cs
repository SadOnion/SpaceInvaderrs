using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandlerPlayer : MonoBehaviour
{
    public GameObject baseBullet;
    public Transform[] spawnShot;

    private Player player;
    private float timer;
    private bool boosted;
    private bool canFire=true;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        timer = player.stats.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && canFire)
        {
            ShootMethod();
            timer = boosted ? player.stats.fireRate*.5f : player.stats.fireRate;
        }
    }

    private void ShootMethod()
    {
        switch (player.stats.fireType)
        {
            case FireType.Single:
                    BaseShootMethod();
                    return;
            case FireType.Double:
                    DoubleShootMethod();
                    return;
            case FireType.Triple:
                    TripleShootMethod();
                    return;
        }
    }

    private void BaseShootMethod()
    {
        GameObject o = Instantiate(baseBullet,spawnShot[0].position,baseBullet.transform.rotation);
        AudioManager.instance.Play("Player");
    }
    private void DoubleShootMethod()
    {
        Instantiate(baseBullet,spawnShot[2].position,baseBullet.transform.rotation);
        Instantiate(baseBullet,spawnShot[1].position,baseBullet.transform.rotation);
        AudioManager.instance.Play("Player");
    }
    private void TripleShootMethod()
    {
        Instantiate(baseBullet,spawnShot[2].position,baseBullet.transform.rotation);
        Instantiate(baseBullet,spawnShot[1].position,baseBullet.transform.rotation);
        Instantiate(baseBullet,spawnShot[0].position,baseBullet.transform.rotation);
        AudioManager.instance.Play("Player");
    }
    public void PowerUp()
    {
        StopAllCoroutines();
        if(boosted){
            timer=player.stats.fireRate;
            boosted=false;
        }
        StartCoroutine(Boost());
        
    }
    private IEnumerator Boost()
    {
        boosted=true;
        timer*=.5f;
        yield return new WaitForSeconds(8);
        boosted=false;
        timer=player.stats.fireRate;
    }
    public void StopShooting()=>canFire=false;
    public void StartShooting()=>canFire=true;
}

