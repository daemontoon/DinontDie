using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanScript : MonoBehaviour
{
    Animator animVolcan;
    CapsuleCollider2D colliderVolcan;
    CircleCollider2D colliderVolcanBig;
    float countBig = 0f;

    void Awake()
    {
        animVolcan = gameObject.transform.GetComponentInChildren<Animator>();
        colliderVolcan = GetComponent<CapsuleCollider2D>();
        colliderVolcanBig = GetComponent<CircleCollider2D>();
        colliderVolcan.enabled = !colliderVolcan.enabled;
        colliderVolcanBig.enabled = !colliderVolcanBig.enabled;
    }


    void Update()
    {
        if (countBig > 2 && colliderVolcanBig.enabled)
        {

            Debug.Log("bAAAAH");

            colliderVolcanBig.enabled = false;
        }

        if (animVolcan.GetCurrentAnimatorStateInfo(0).IsName("VolcanRise"))
        {


            colliderVolcanBig.enabled = true;
            if (colliderVolcanBig.radius < 1.5)
            {
                colliderVolcanBig.radius += Time.deltaTime;
            }
            else
            {
                colliderVolcan.enabled = true;
                colliderVolcanBig.enabled = false;
            }

        }

        if (colliderVolcanBig.enabled)
        {
            countBig += 0;        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // if (animVolcan.GetCurrentAnimatorStateInfo(0).IsName("VolcanRise")) Destroy(collision.collider.gameObject.transform.parent.gameObject);

    }
}



        //  

