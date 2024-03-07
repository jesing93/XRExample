using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;
    public GunType type;
    private Rigidbody rb;
    public bool isHeld = true;
    [SerializeField] private Transform holderTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isHeld)
        {
            if (rb.velocity.magnitude < 0.1f)
            {
                ReturnToHolder();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isHeld)
        {
            ReturnToHolder();
        }
    }

    private void ReturnToHolder()
    {
        transform.parent = holderTransform;
        transform.localPosition = Vector3.zero;
    }

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
