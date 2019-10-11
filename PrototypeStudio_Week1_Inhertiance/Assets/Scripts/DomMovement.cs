using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomMovement : MonoBehaviour
{
    public float movingSpeed;
    
    private float rotatingSpeed = 0;
    public float rotatingAc;
    public float rotatingMax;

    private float looptime;
    
    // Start is called before the first frame update
    void Start()
    {
        //random looptime
        looptime = Random.Range(3f, 7f);
        
        //random rotation
        transform.eulerAngles = new Vector3(0,0,Random.Range(-180,180));
        //random position
        transform.position = new Vector3(Random.Range(-8,8),Random.Range(-4.3f,4.3f),0);
        
        //random rotating direction
        float[] possibleRotatingAc = new float[] {-rotatingAc,rotatingAc};
        int randomRoatingAc = Random.Range(0, possibleRotatingAc.Length);

        rotatingAc = possibleRotatingAc[randomRoatingAc];
    }

    // Update is called once per frame
    void Update()
    {
        randomMovement();
    }

    void randomMovement()
    {
        //make it move at constant speed
        GetComponent<Rigidbody2D>().velocity = transform.up*movingSpeed;
        
        //make it rotate with random speed
        transform.eulerAngles += new Vector3(0,0,rotatingSpeed);

        rotatingSpeed += rotatingAc;

        if (rotatingSpeed >= rotatingMax)
            rotatingSpeed = rotatingMax;
        else if (rotatingSpeed <= -rotatingMax)
            rotatingSpeed = -rotatingMax;
        
        //make it rotate in some kind of random loop
        looptime -= Time.deltaTime;
        if (looptime <= 0)
        {
            looptime = Random.Range(5f, 10f);
            rotatingAc = -rotatingAc;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Dom"))
        {
            Destroy(gameObject);
        }
    }
}
