using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
   public GameObject projectile;
    public void Shoot()
    {
        GameObject o =Instantiate(projectile,transform.position,transform.rotation);
        AudioManager.instance.Play("Enemy");
    }
}
