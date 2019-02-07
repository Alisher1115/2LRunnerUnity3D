using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private float speed;

    // [SerializeField]
    // private float turnSpeed; 

    [SerializeField]
    private float sideSpeed;

    [SerializeField]
    private int score = 0;

    [SerializeField]
    private Vector3 playerStartPosition;
    [SerializeField]
    private float startX, startY, startZ;

    [SerializeField]
    private Vector3 obstacleCollisionPosition;
    private float collisionPushPowerZ = 5;

    [SerializeField]
    private Vector3 obstacleUpCollisionPosition;
    private float collisionPushUpPowerY = 5;

    public Action onGameOver;
    public Action onGameWin;

    // Use this for initialization
    void Start()
    {
        startX = (float)0.13;
        startY = (float)3.17;
        startZ = (float)-46.52;
        playerStartPosition = new Vector3(startX, startY, startZ);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("a"))
        {
            //move left
            rigidbody.AddForce(-sideSpeed * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        else if (Input.GetKey("d"))
        {
            //move right
            rigidbody.AddForce(sideSpeed * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        else if (Input.GetKey("w"))
        {
            //increase speed
            // speed = speed * Time.deltaTime;
            speed += 15;
        }
        else if (Input.GetKey("s"))
        {
            //decrease speed
            speed -= 15;
        }

        // float currentX = this.transform.position.x;
        // float currentZ = this.transform.position.z;
        float currentY = this.transform.position.y;

        if (currentY < -1)
        {
            this.transform.position = this.playerStartPosition;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        float currentX = this.transform.position.x;
        float currentY = this.transform.position.y;
        float currentZ = this.transform.position.z;

        //выполняем проверку по тэгу обьекта
        if (other.gameObject.tag == "Obstacle")
        {
            // this.enabled = false;
            this.obstacleCollisionPosition = new Vector3(currentX, currentY, currentZ - collisionPushPowerZ);
            this.transform.position = this.obstacleCollisionPosition;
            this.enabled = false;
            if (onGameOver != null)
            {
                onGameOver();
            }
        }
        if (other.gameObject.tag == "Jump")
        {
             this.obstacleUpCollisionPosition = new Vector3(currentX, currentY + collisionPushUpPowerY, currentZ);
            this.transform.position = this.obstacleUpCollisionPosition;
        }

        if (other.gameObject.tag == "GameWinTrigger")
        {
            this.enabled = false;
            if (onGameWin != null)
            {
                onGameWin();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            score += 5;
            if (score % 5 == 0)
            {
                speed += 5;
            }
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        // if (score >= 15)
        // {
        //     if (onGameWin != null)
        //     {
        //         onGameWin();
        //     }
        // }
    }
}
