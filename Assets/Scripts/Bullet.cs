using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private string targetTag = "Target";
    private bool isHit;
    private float timeAlive;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isHit)
        {
            isHit = true;
            GetComponent<AudioSource>().Play();
            if (collision.gameObject.tag == targetTag)
            {
                collision.gameObject.GetComponent<Target>().Hit();
            }
            StartCoroutine(AutoDestroy());
        }
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive > 2)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(this.gameObject);
    }

}
