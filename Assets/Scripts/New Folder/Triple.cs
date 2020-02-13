using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="RedItem",menuName ="Item/Triple")]
public class Triple : Item
{
    public override void ShootMethod()
    {
       for (int i = 0; i < 3; i++)
        {
            GameObject o = Instantiate(bullet, shotingHandler.spawnShot[i].position, bullet.transform.rotation);
            Destroy(o, 3);
            
        }
    }
}
