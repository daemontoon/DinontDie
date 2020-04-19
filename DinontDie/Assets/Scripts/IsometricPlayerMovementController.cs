using System.Collections;
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
    public float independance = 1f;

    public Vector2 mousePos = new Vector2(0, 0);
    public Vector2 inputVector = new Vector2(0, 0);
    public Vector2 inputVector2 = new Vector2(0, 0);
    public Vector2 randomDirection = new Vector2(0, 0);
    public Vector2 randomVector = new Vector2(0, 0);
    public Vector2 currentPos = new Vector2(0, 0);
    public Vector2 movement;

    float energy;

    public float randomNumber = 0f;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        energy = GameObject.Find("GameManager").GetComponent<gameManager>().energy;
        currentPos = rbody.position;
        inputVector2 = GameObject.Find("GameManager").GetComponent<gameManager>().inputVector;
        inputVector2 = inputVector2 - currentPos;
        inputVector2 = Vector2.ClampMagnitude(inputVector2, 1);

        if (Input.GetMouseButton(0) == false || energy <= 0)
        {
            inputVector2 = new Vector2(0, 0);
            Debug.Log("appuyé");
        }


        if (inputVector2 == new Vector2(0,0))
        {
            idleTimer += Time.deltaTime*independance;
        }
        else
        {
            idleTimer = 0;
        }

       


        

        if (idleTimer > 1)
        {
            if (randomDirection == new Vector2(0, 0))
            {
                randomDirection += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }

            randomVector = Vector2.ClampMagnitude(randomDirection, 1);

        }
        else
        {
            randomVector = new Vector2(0, 0);
        }

        randomNumber = Random.Range(0, 100)+idleTimer*2;
        if (randomNumber > 98)
        {
            randomDirection = new Vector2(0, 0);
            idleTimer = 0;
        }

        movement = inputVector2 * movementSpeed + randomVector * movementSpeed;

        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //isoRenderer.SetDirection(movement);
        
        rbody.MovePosition(newPos);
    }
}
