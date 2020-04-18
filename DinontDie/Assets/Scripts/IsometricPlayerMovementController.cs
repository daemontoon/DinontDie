﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public Text UIvaleur;
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    public float idleTimer;
    Rigidbody2D rbody;


    public Vector2 mousePos = new Vector2(0, 0);
    public Vector2 inputVector = new Vector2(0, 0);
    public Vector2 inputVector2 = new Vector2(0, 0);
    public Vector2 randomDirection = new Vector2(0, 0);
    public Vector2 randomVector = new Vector2(0, 0);
    public Vector2 currentPos = new Vector2(0, 0);
    public Vector2 movement;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            inputVector2 = new Vector2(mousePos.x, mousePos.y);
            inputVector2 = inputVector2 - currentPos;
            inputVector2 = Vector2.ClampMagnitude(inputVector2, 1);


        if (Input.GetMouseButton(0) == false)
        {
            inputVector2 = new Vector2(0, 0);
            Debug.Log("appuyé");
        }


        if (inputVector2 == new Vector2(0,0))
        {
            idleTimer += Time.deltaTime;
        }
        else
        {
            idleTimer = 0;
        }

       
        inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        

        if (idleTimer > 3)
        {
            randomDirection += new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            randomVector = Vector2.ClampMagnitude(randomDirection, 1);
        }
        else
        {
            randomVector = new Vector2(0, 0);
        }

        movement = inputVector2 * movementSpeed + randomVector * movementSpeed/100;

        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //isoRenderer.SetDirection(movement);
        
        rbody.MovePosition(newPos);
    }
}