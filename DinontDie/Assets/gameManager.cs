using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public Camera cam;
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
    public bool Menu;


    public float annee = -150000000;
    public float time = 0;
    public int eraDuration;
    public int eraNow = 0;
    string[] eras = new string[] { "Prehistory", "Ancient history", "Middle Ages", "Renaissance", "Modern Times", "Future" };
    float[] eraMeteor = new float[] { 3,4,2,2,1,1};
    float[] eraVolcan = new float[] { 10,7,8,5,2,3};
    public int startAnnee = -150000000;
    public int[] erasTime = new int[] { -5000, 250, 1450, 1780, 2020, 150000000 };
    public bool win = false;



    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
        if (!Menu)
        {
            freqMeteor = eraMeteor[eraNow];
            freqVolcan = eraVolcan[eraNow];
        }


    }

    // Update is called once per frame
    private void Update()
    {
        if (!Menu && !win)
        { 
        time += Time.deltaTime;
        annee = Mathf.Round(startAnnee + (time/eraDuration) * (erasTime[eraNow] - startAnnee) ) ;

        if (annee < -10000)
        {
            textAnnee.text = "Year " + System.Math.Round(-annee / 1000000f).ToString() + "M B.C.";
        }
        else if ( annee > 10000 )
        {
            textAnnee.text = "Year " + System.Math.Round(annee / 1000000f).ToString() + "M A.C.";
        }

        else if (annee >= -100 && annee <= 100)
        {
            textAnnee.text = "Year " + System.Math.Round(annee / 10f).ToString() + "0";
        }
        else
        {
            textAnnee.text = "Year " + System.Math.Round(annee / 10f).ToString()+"0";
        }


        if (time >= eraDuration)
        {

            time = 0;
            startAnnee = erasTime[eraNow];
            eraNow++;
                if (eraNow == 6) win = true;
            if (!win)
                { 
                    Debug.Log(eras[eraNow]);
            GameObject temps;
            temps = GameObject.Find("LevelMenu");
            temps.GetComponent<ChangeLevel>().changeLevel(eraNow);
            freqMeteor = eraMeteor[eraNow];
            freqVolcan = eraVolcan[eraNow];
                }


            }
        }
    }
    void FixedUpdate()
    {


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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

        if (!Menu) barre.value = energy/maxEnergy ;

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
