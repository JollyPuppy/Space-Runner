using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingposition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingposition = transform.position;    
        
    }

    // Update is called once per frame
    void Update()
    {   
        const float tau = Mathf.PI * 2; //constant value of 6.283
       
        if (period <= Mathf.Epsilon) //always compare a float number to this rather than 0
        {
            return;
        }
        float cycles = Time.time / period; //continually grows over time
         
       
        float rawSinWave = Mathf.Sin(cycles * tau); //going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingposition + offset;
    }
}
