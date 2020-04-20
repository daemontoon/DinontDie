using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanScript : MonoBehaviour
{
    Animator animVolcan;
    Animator animLava;
    CapsuleCollider2D colliderVolcan;
    CircleCollider2D colliderVolcanBig;
    PolygonCollider2D colliderLave;
    SpriteRenderer spriteVolcan;
    SpriteRenderer spriteLava;
    float countBig = 0f;

    void Awake()
    {
        spriteVolcan = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteLava = transform.GetChild(1).GetComponent<SpriteRenderer>();
        animVolcan = transform.GetChild(0).GetComponent<Animator>();
        animLava = transform.GetChild(1).GetComponent<Animator>();
        colliderLave = GetComponent<PolygonCollider2D>();
        colliderVolcan = GetComponent<CapsuleCollider2D>();
        colliderVolcanBig = GetComponent<CircleCollider2D>();
        colliderVolcan.enabled = !colliderVolcan.enabled;
        colliderVolcanBig.enabled = !colliderVolcanBig.enabled;
        //FindObjectOfType<AudioManager>().Play("Volcano");
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
        if (animVolcan.GetCurrentAnimatorStateInfo(0).IsName("VolcanIdle"))
            {
            animLava.SetBool("go", true);
            spriteVolcan.sortingOrder = -1;
            spriteLava.sortingOrder = 0;

        }

        if (colliderVolcanBig.enabled)
        {
            countBig += 0;        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (animLava.GetCurrentAnimatorStateInfo(0).IsName("LavaFin"))
        {
               // FindObjectOfType<AudioManager>().Play("PlayerDeath");
            collision.collider.gameObject.transform.parent.gameObject.GetComponent<IsometricPlayerMovementController>().Mourrir();
        }

    }

}



        //  

