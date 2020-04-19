using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject volcanPrefab;
    public float meteorCounter = 0;
    public float volcanCounter = 0;
    public float freqMeteor;
    public float freqVolcan;

    float horizontalInput;
    float verticalInput;
    public Vector2 inputVector = new Vector2(0, 0);
    public float energy;
    public float maxEnergy;
    public float regen;
    public float conso;
    public Vector2 mousePos;

    public Slider barre;

    public TMP_Text textAnnee;


    public float annee = -150000000;
    public float time = 0;
    public int eraDuration;
    int eraNow = 0;
    public string[] eras = new string[] { "Pré-histoire", "Antiquité", "Moyen-âge", "Renaissance", "Temps modernes", "Futur" };
    public int startAnnee = -150000000;
    public int[] erasTime = new int[] { -5000, 250, 1450, 1780, 2020, 150000000 };

    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;

    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        annee = Mathf.Round(startAnnee + (time/eraDuration) * (erasTime[eraNow] - startAnnee) ) ;

        if (annee < -10000)
        {
            textAnnee.text = "Year " + System.Math.Round(-annee / 1000000f).ToString() + " 000 000 B.C.";
        }
        else if ( annee > 10000 )
        {
            textAnnee.text = "Year " + System.Math.Round(annee / 1000000f).ToString() + "M";
        }

        else if (annee >= -100 && annee <= 100)
        {
            textAnnee.text = "Year " + System.Math.Round(annee / 10f).ToString() + "0";
        }
        else
        {
            textAnnee.text = "Year " + System.Math.Round(annee / 100f).ToString()+"00";
        }


        if (time >= eraDuration)
        {

            time = 0;
            startAnnee = erasTime[eraNow];
            eraNow++;
            Debug.Log(eras[eraNow]);

        }
    }
    void FixedUpdate()
    {


        mousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
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
        volcanCounter += Time.deltaTime;
        if (meteorCounter > freqMeteor)
        {
            InvokeMeteor();
            meteorCounter = 0f;
        }
        if (volcanCounter > freqVolcan)
        {
            InvokeVolcan();
            volcanCounter = 0f;
        }

        if (energy < 0) energy = 0;
        barre.value = Mathf.Pow(energy / maxEnergy,2) ;

    }
    void InvokeMeteor ()
    {
        Vector2 randomPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4f, 3.5f));
        Instantiate(meteorPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);
    }
    void InvokeVolcan()
    {
        Vector2 randomPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4f, 3.5f));
        Instantiate(volcanPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);
    }
}
