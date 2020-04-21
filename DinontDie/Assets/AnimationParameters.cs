using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AnimationParameters : MonoBehaviour
{
    public GameObject perso;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 movementValue;
    public bool isMoving;
    int era;
    public AudioSource son;
    public AudioMixerGroup mixerGroup;
    bool joue = false;

    // Start is called before the first frame update
    private void Start()
    {
        
        son.outputAudioMixerGroup = mixerGroup;
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
            Debug.Log("go");
            if (joue == false)
            {
                if (!son.isPlaying) son.Play();
                joue = true;
            }

        }
        else
        {
            isMoving = false;
            if (son.isPlaying) son.Stop();
            joue = false;
           // GameObject.Find("AudioManager").GetComponent<AudioManager>().("AnimDino");
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
