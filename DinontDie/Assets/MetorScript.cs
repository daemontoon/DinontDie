﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetorScript : MonoBehaviour
{
    Animator animMeteor;
    SpriteRenderer spriteMeteor;
    CapsuleCollider2D colliderMeteor;
    List<GameObject> TriggerList = new List<GameObject>();
    void Awake()
    {
        animMeteor = gameObject.transform.GetComponentInChildren<Animator>();
        spriteMeteor = gameObject.transform.GetComponentInChildren<SpriteRenderer>();
        spriteMeteor.sortingLayerName = "Foreground";
        colliderMeteor = GetComponent<CapsuleCollider2D>();
        colliderMeteor.enabled = !colliderMeteor.enabled;
        FindObjectOfType<AudioManager>().Play("MeteorCrash");
    }

    /* private void OnTriggerEnter2D(Collider2D other)
     {
         //if the object is not already in the list
         if (!TriggerList.Contains(other.gameObject))
         {
             //add the object to the list
             TriggerList.Add(other.gameObject);
         }
     }
     private void OnTriggerExit(Collider2D other)
     {
         //if the object is not already in the list
         if (TriggerList.Contains(other.gameObject))
         {
             //add the object to the list
             TriggerList.Remove(other.gameObject);
         }
     }*/
    void Update()
    {
        //Debug.Log("compte = " + TriggerList.Count);
        if (animMeteor.GetCurrentAnimatorStateInfo(0).IsName("MeteorCrash"))

        {
            //FindObjectOfType<AudioManager>().Play("MeteorCrash");

            Debug.Log("layer" + spriteMeteor.sortingLayerName);
            spriteMeteor.sortingLayerName = "Default";


            colliderMeteor.enabled = true;

            /*while (TriggerList.Count > 0)
            {
                Destroy(TriggerList[0].transform.parent.gameObject);
                TriggerList.RemoveAt(0);                  
            }*/
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (animMeteor.GetCurrentAnimatorStateInfo(0).IsName("MeteorCrash"))
        {
           
            collision.collider.gameObject.transform.parent.gameObject.GetComponent<IsometricPlayerMovementController>().Mourrir();
        }
       FindObjectOfType<AudioManager>().Play("PlayerDeath");


    }


}
