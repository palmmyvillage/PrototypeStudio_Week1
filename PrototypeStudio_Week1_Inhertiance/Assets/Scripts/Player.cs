using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] shape;
    private int shapeNumber = 0;
    public GameObject aura;
    public Sprite[] auraShape;

    public int colornumber = 2;
    
    public float acceleration;
    public float maxSpeed;
    private float vSpeed;
    private float vAc;
    private float hSpeed;
    private float hAc;

    private float xPos;
    private float yPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //moving
        vAc = Input.GetAxis("Vertical") * acceleration;
        hAc = Input.GetAxis("Horizontal") * acceleration;
        
        vSpeed += vAc;
        if (vSpeed >= maxSpeed)
            vSpeed = maxSpeed;
        else if (vSpeed <= -maxSpeed)
            vSpeed = -maxSpeed;
        yPos += vSpeed;

        hSpeed += hAc;
        if (hSpeed >= maxSpeed)
            hSpeed = maxSpeed;
        else if (hSpeed <= -maxSpeed)
            hSpeed = -maxSpeed;
        xPos += hSpeed;

        if (xPos >= 8.5f)
        {
            xPos = 8.45f;
            hSpeed = 0;
        }
        else if (xPos <= -8.5f)
        {
            xPos = -8.45f;
            hSpeed = 0;
        }

        if (yPos >= 4.6f)
        {
            yPos = 4.55f;
            vSpeed = 0;
        }
        else if (yPos <= -4.6f)
        {
            yPos = -4.55f;
            vSpeed = 0;
        }
        
        transform.position = new Vector3(xPos,yPos,0);
        
        //rotating
        transform.eulerAngles += new Vector3(0,0,Input.GetAxis("Horizontal")*-0.4f);
    }

    void changeShape()
    {
        if (shapeNumber <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = shape[0];
            aura.GetComponent<SpriteRenderer>().sprite = auraShape[0];
            shapeNumber = 0;
        }

        if (shapeNumber == 1)
        {
            GetComponent<SpriteRenderer>().sprite = shape[1];
            aura.GetComponent<SpriteRenderer>().sprite = auraShape[1];
        }
        
        if (shapeNumber >= 2)
        {
            GetComponent<SpriteRenderer>().sprite = shape[2];
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

        if (other.gameObject.CompareTag("Dom"))
        {
            int winningScore = 0;
            if (other.gameObject.GetComponent<DomSpecies>().shapeNumber == shapeNumber)
                winningScore++;
            if (other.gameObject.GetComponent<DomSpecies>().colornumber == colornumber)
                winningScore++;

            if (winningScore >= 2)
            {
                transform.localScale *= 1.2f;
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
