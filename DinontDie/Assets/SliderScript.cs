using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Image img;
    Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        baseColor = img.color;
    }
    public GameObject GameObjectToShake;
    bool shaking = false;

    IEnumerator shakeGameObjectCOR(GameObject objectToShake, float totalShakeDuration, float decreasePoint, bool objectIs2D = false, float angleR = 1f)
    {
        if (decreasePoint >= totalShakeDuration)
        {
            Debug.LogError("decreasePoint must be less than totalShakeDuration...Exiting");
            decreasePoint = totalShakeDuration;
        }

        //Get Original Pos and rot
        Transform objTransform = objectToShake.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;

        float counter = 0f;

        //Shake Speed
        const float speed = 0.1f;

        //Angle Rotation(Optional)
        float angleRot = angleR;

        //Do the actual shaking
        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float decreaseSpeed = speed;
            float decreaseAngle = angleRot;

            //Shake GameObject
            if (objectIs2D)
            {
                //Don't Translate the Z Axis if 2D Object
                Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                tempPos.z = defaultPos.z;
                objTransform.position = tempPos;

                //Only Rotate the Z axis if 2D
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
            }
            else
            {
                objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
            }
            yield return null;


            //Check if we have reached the decreasePoint then start decreasing  decreaseSpeed value
            if (counter >= decreasePoint)
            {
                Debug.Log("Decreasing shake");

                //Reset counter to 0 
                counter = 0f;
                while (counter <= decreasePoint)
                {
                    counter += Time.deltaTime;
                    decreaseSpeed = Mathf.Lerp(speed, 0, counter / decreasePoint);
                    decreaseAngle = Mathf.Lerp(angleRot, 0, counter / decreasePoint);

                    Debug.Log("Decrease Value: " + decreaseSpeed);

                    //Shake GameObject
                    if (objectIs2D)
                    {
                        //Don't Translate the Z Axis if 2D Object
                        Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        tempPos.z = defaultPos.z;
                        objTransform.position = tempPos;

                        //Only Rotate the Z axis if 2D
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(0f, 0f, 1f));
                    }
                    else
                    {
                        objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(1f, 1f, 1f));
                    }
                    yield return null;
                }

                //Break from the outer loop
                break;
            }
        }
        objTransform.position = defaultPos; //Reset to original postion
        objTransform.rotation = defaultRot;//Reset to original rotation

        shaking = false; //So that we can call this function next time
        Debug.Log("Done!");
    }


    void shakeGameObject(GameObject objectToShake, float shakeDuration, float decreasePoint, bool objectIs2D = false, float angleR = 1f)
    {
        if (shaking)
        {
            return;
        }
        shaking = true;
        StartCoroutine(shakeGameObjectCOR(objectToShake, shakeDuration, decreasePoint, objectIs2D, angleR));
    }


    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Slider>().value < 0.33)
        {

            if (GetComponent<Slider>().value < 0.15 && GetComponent<Slider>().value >= 0.05)
            {
                shakeGameObject(gameObject, Time.deltaTime, Time.deltaTime / 1000, true, (0.15f - GetComponent<Slider>().value));
            }
            if (GetComponent<Slider>().value < 0.05)
            {
                shakeGameObject(gameObject, Time.deltaTime, Time.deltaTime / 1000, true, 2);
            }


            img.color = new Color(baseColor.r +(1f - 3f*GetComponent<Slider>().value), baseColor.g * 3f*GetComponent<Slider>().value, baseColor.b *3f*GetComponent<Slider>().value, 1);
        }
        else
        {
            img.color = baseColor;
        }
    }
}
