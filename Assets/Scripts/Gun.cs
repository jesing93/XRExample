using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;
    public GunType type;

    public void TriggerPress()
    {
        if(type == GunType.Pistol)
        {
            Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
        }
        else
        {
            //TODO Attract
        }
    }
    public void TriggerUnPress()
    {
        if (type == GunType.Magnet)
        {
            //TODO Repulse
        }
    }
}

public enum GunType
{
    Pistol,
    Magnet
}
