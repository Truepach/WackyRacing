using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 4f;

    bool movingLeft = true;
    bool firstInput = true;
    bool powerUp = false;
    int powerUpType;

    public GameObject pickUpEffect;
    private Audio audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = FindObjectOfType<Audio>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (GameManager.instance.isGameStarted)
        {
            CheckPowerUp();
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

    public virtual void CheckPowerUp()
    {
        if (powerUp)
        {
            if (powerUpType == 1)
            {
                moveSpeed += 1;
            }
            else if (powerUpType == 2)
            {
                if (moveSpeed > 1)
                {
                    moveSpeed -= 1;
                }
            }
            powerUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp1")
        {
            powerUpType = 1;
            Destroy(other.gameObject);
            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);
            powerUp = true;
            audioPlayer.PlayPickupSound();
        }
        else if (other.gameObject.tag == "PowerUp2")
        {
            powerUpType = 2;
            Destroy(other.gameObject);
            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);
            powerUp = true;
            audioPlayer.PlayPickupSound();
        }
    }

}
