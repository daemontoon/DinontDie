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

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Slider>().value < 0.33)
        {

            img.color = new Color(baseColor.r +(1f - 3f*GetComponent<Slider>().value), baseColor.g * 3f*GetComponent<Slider>().value, baseColor.b *3f*GetComponent<Slider>().value, 1);
        }
        else
        {
            img.color = baseColor;
        }
    }
}
