using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float meteorCounter = 0;
    public float freqMeteor;
    float horizontalInput;
    float verticalInput;
    public Vector2 inputVector = new Vector2(0, 0);
    public float energy;
    public float maxEnergy;
    public float regen;
    public float conso;
    public Vector2 mousePos;

    public Slider barre;

    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            
            InvokeMeteor();



        }
        inputVector = new Vector2(mousePos.x, mousePos.y);
        if (Input.GetMouseButton(0) == false)
        {
            inputVector = new Vector2(0, 0);
            if(energy<maxEnergy)
            {
                energy += Time.deltaTime*regen;
            }
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
                
        }
        else
        {
            energy -= Time.deltaTime *conso;



        }
        meteorCounter += Time.deltaTime;
        if (meteorCounter > freqMeteor)
        {
            InvokeMeteor();
            meteorCounter = 0f;
        }

        if (energy < 0) energy = 0;
        barre.value = Mathf.Pow(energy / maxEnergy,2) ;

    }
    void InvokeMeteor ()
    {
        Vector2 randomPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4f, 3.5f));
        Instantiate(meteorPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);
    }
}
