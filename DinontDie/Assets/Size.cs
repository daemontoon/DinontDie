using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{

    void Start()
    {
        float Height = Size.GetScreenToWorldHeight/10;
        float width = Size.GetScreenToWorldWidth / 10;
        if ( width / Height <= 16/9)
        {
            transform.localScale = Vector3.one * width;
        }
        else
            {
            transform.localScale = Vector3.one * Height;
        }

    }

    public static float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var height = edgeVector.y * 2;
            return height;
        }
    }
    public static float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var width = edgeVector.x * 2;
            return width;
        }
    
    }       
}
