using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private string targetTag = "Target";
    private bool isHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isHit)
        {
            isHit = true;
            if (collision.gameObject.tag == targetTag)
            {
                collision.gameObject.GetComponent<Target>().Hit();
            }
            Destroy(this.gameObject);
        }
    }
}
