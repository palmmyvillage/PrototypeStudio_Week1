using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PreyGenerator : MonoBehaviour
{
    //sprite generation 
    public Sprite[] shape;
    private int shapeNumber;
    public bool isCircle;

    //aura generation
    public GameObject aura;
    public Sprite[] auraSprite;
    
    //bool for color
    public bool isWhite;
    
    // Start is called before the first frame update
    void Start()
    {
        //set up shape number to perform other function
        shapeNumber = shape.Length;
        
        RandomGeneratation();
    }

    // Update is called once per frame
    void Update()
    {
        //for debug
        //if (Input.GetKeyDown(KeyCode.R))
        //   RandomGeneratation();
    }

    void RandomGeneratation()
    {
        //random shape
        int outcomeShape = Random.Range(0, shape.Length);
        GetComponent<SpriteRenderer>().sprite = shape[outcomeShape];
        //Make Aura get along
        aura.GetComponent<SpriteRenderer>().sprite = auraSprite[outcomeShape];
        //set the bool
        if (outcomeShape == 0)
            isCircle = true;
        else if (outcomeShape == 1)
            isCircle = false;
        
        //random color
        float[] colorValue = new float[] {0.2f,1}; // ini the color value to random
        int randomColor = Random.Range(0,colorValue.Length); // random the index of colorValue
        
        GetComponent<SpriteRenderer>().color = new Color(colorValue[randomColor],colorValue[randomColor],colorValue[randomColor]);

        if (randomColor == 0)
            isWhite = false;
        else if (randomColor == 1)
            isWhite = true;
    }
}
