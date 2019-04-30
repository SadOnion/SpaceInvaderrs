using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingHandler : MonoBehaviour
{
    public GameObject baseBullet;
    public Attack howToAttack;
    public float timeBtwShots=.75f;
    private float time;
    public Transform[] spawnShot;
    private delegate void Shoot();
    Shoot shootMethod;
    // Start is called before the first frame update
    void Start()
    {
        time = timeBtwShots;
        shootMethod = GiveProperAttack();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            shootMethod();
            time = timeBtwShots;
        }
    }
    private Shoot GiveProperAttack()
    {
        switch (howToAttack)
        {
            case Attack.Base:
                return BaseShootMethod;
                
            case Attack.Triple:
                return TripleShot;
            case Attack.TriBurst:
                return TriBurst;
            case Attack.TriAngle:
                return EnemyTriAngle;
            default:
                return BaseShootMethod;
                
        }
    }
    private void TripleShot()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject o = Instantiate(baseBullet, spawnShot[i].position, baseBullet.transform.rotation);
            Destroy(o, 3);

        }
    }
    private void EnemyTriAngle()
    {
        for (int i = 0; i < 3; i++)
        {
        GameObject o = Instantiate(baseBullet, spawnShot[i].position, baseBullet.transform.rotation);
        o.GetComponent<Mover>().SetVelocity(new Vector2(1-i,-1).normalized*-1);
        Destroy(o, 3);
        }
    }
    private void CreateBullet(int spawnPoint)
    {
        GameObject o = Instantiate(baseBullet, spawnShot[spawnPoint].position, baseBullet.transform.rotation);
        Destroy(o, 3);
    }
    private void TriBurst()
    {
        StartCoroutine(Burst(3));
    }
    private IEnumerator Burst(int x)
    {
        for (int i = 0; i < x; i++)
        {
            CreateBullet(0);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void BaseShootMethod()
    {
        GameObject o = Instantiate(baseBullet,spawnShot[0].position,baseBullet.transform.rotation);
        Destroy(o, 3);
    }
}
public enum Attack
{
    Base,
    Triple,
    TriBurst,
    TriAngle
}
