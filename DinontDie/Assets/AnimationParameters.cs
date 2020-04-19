using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameters : MonoBehaviour
{
    public GameObject perso;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 movementValue;
    public bool isMoving;
    int era;

    // Start is called before the first frame update
    private void Start()
    {
   
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        era = GameObject.Find("GameManager").GetComponent<gameManager>().eraNow;
        animator.SetInteger("era", era);
        movementValue = perso.GetComponent<IsometricPlayerMovementController>().movement;

        if (movementValue != new Vector2(0,0))
        { 
            isMoving = true;
            FindObjectOfType<AudioManager>().Play("Stomping");
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("isMoving", isMoving);


        if (movementValue.x > 0)
        {

            spriteRenderer.flipX = true;
        }
        else if (movementValue.x < 0)
        {
            spriteRenderer.flipX = false;

        }

       
    }

}
