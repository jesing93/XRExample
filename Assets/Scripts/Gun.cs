using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;
    public GunType type;
    //private Rigidbody rb;
    //private OVRGrabber grabber;
    private AudioSource shootSound;
    public bool isRight;
    public bool isHeld = true;
    [SerializeField] private Transform holderTransform;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        //grabber = GetComponent<OVRGrabber>();
        shootSound = GetComponent<AudioSource>();

    }

    /*private void FixedUpdate()
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
    }*/

    private void Update()
    {
        if (isRight)
        {
            //if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            //{
                //Debug.Log("Grabbing");
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("Shooting");
                shootSound.Play();
                Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
            }
            //}
        }
        else
        {
            //if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            //{
                //Debug.Log("Grabbing");
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Debug.Log("Shooting");
                shootSound.Play();
                Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
            }
            //}
        }
    }

    private void ReturnToHolder()
    {
        //rb.useGravity = false;
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
