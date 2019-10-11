using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomSpecies : MonoBehaviour
{
    public Sprite[] shape;
    public int shapeNumber;
    public GameObject core;
    public Sprite[] coreShape;
    public GameObject aura;
    public Sprite[] auraShape;

    public int colornumber;
    
    // Start is called before the first frame update
    void Start()
    {
        shapeNumber = Random.Range(0, 3);
        colornumber = Random.Range(0, 3);
        
        changeShape();
        changeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeShape()
    {
        if (shapeNumber <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = shape[0];
            core.GetComponent<SpriteRenderer>().sprite = coreShape[0];
            aura.GetComponent<SpriteRenderer>().sprite = auraShape[0];
            shapeNumber = 0;
        }

        if (shapeNumber == 1)
        {
            GetComponent<SpriteRenderer>().sprite = shape[1];
            core.GetComponent<SpriteRenderer>().sprite = coreShape[1];
            aura.GetComponent<SpriteRenderer>().sprite = auraShape[1];
        }
        
        if (shapeNumber >= 2)
        {
            GetComponent<SpriteRenderer>().sprite = shape[2];
            core.GetComponent<SpriteRenderer>().sprite = coreShape[2];
            aura.GetComponent<SpriteRenderer>().sprite = auraShape[2];
            shapeNumber = 2;
        }        
    }

    void changeColor()
    {
        if (colornumber <= 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.2f,0.2f,0.2f);
            colornumber = 0;
        }

        if (colornumber == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.6f,0.6f,0.6f);
        }
        
        if (colornumber >= 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(1,1,1);
            colornumber = 2;
        }  
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Prey"))
        {
            if (other.gameObject.GetComponent<PreyGenerator>().isCircle == true)
            {
                shapeNumber -= 1;
                changeShape();
            }
            else
            {
                shapeNumber += 1;
                changeShape();
            }

            if (other.gameObject.GetComponent<PreyGenerator>().isWhite == true)
            {
                colornumber += 1;
                changeColor();
            }
            else
            {
                colornumber -= 1;
                changeColor(); 
            }
            
            Destroy(other.gameObject);
        }
    }
}
