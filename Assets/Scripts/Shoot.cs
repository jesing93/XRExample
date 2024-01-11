using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);

            }
        }

    }
}
