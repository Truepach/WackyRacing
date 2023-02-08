using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TitleCar : CarController
{
    public float amplitude = 3.0f;
    public float rotationSpeed;
    private bool shouldStopMovement = false;



    public override void Update()  //INHERITANCE
    {
        if (transform.position.x >= -0.1 && transform.position.x <= 0.1)
        {
            StopMovement();
        }
        else
        {
            if(!shouldStopMovement)
            {
                Move();                
            }
            else
            {
                Spin();
            }

        }
    }

    public override void Move() //INHERITANCE
    {
        float y = Mathf.Sin(Time.time * moveSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, y, transform.position.z);
    }

    public void MoveForward()
    {
        transform.position = new Vector3(transform.position.x + (moveSpeed * 2) * Time.deltaTime, transform.position.y, transform.position.z);
    }
    private void StopMovement()
    {
        shouldStopMovement= true;
    }


    private void Spin()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }    

}
