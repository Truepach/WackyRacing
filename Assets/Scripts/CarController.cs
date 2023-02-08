using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;

    bool movingLeft = true;
    bool firstInput = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (GameManager.instance.isGameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    public virtual void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public virtual void CheckInput() //ABSTRACTION
    {
        //if first input than ignore 
        if(firstInput)
        {
            firstInput= false;
            return;
        }
        if(Input.GetMouseButtonDown(0)) 
        {
            ChangeDirection();
        }

    }

    public virtual void ChangeDirection()  //ABSTRACTION
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;  
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }
}
