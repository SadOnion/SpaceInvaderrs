using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="RedItem",menuName ="Item/RedItem")]
public class RedLaser : Item
{
    public override void ShootMethod()
    {
        GameObject o = Instantiate(bullet,shotingHandler.spawnShot[0].position,bullet.transform.rotation);
        Destroy(o, 3);
    }
}
