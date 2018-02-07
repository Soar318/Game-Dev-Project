using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float xSpeed = 13f;
    public float ySpeed = 17f;
    public int floorNumber = 1;
    public int health = 5;

    Rigidbody myRigidbody;
    BoxCollider myCollider;

    private bool isJumping = false;
    private bool isMoving = false;

    public GameObject carrotSprite;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update () {

        //Gen Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isJumping != true)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, ySpeed);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) && isJumping != true)
        {
            myCollider.size = new Vector3(19.39f, 8f, 7.261f);
            myCollider.center = new Vector3(0f, -4, 0f);
        }
        else if (Input.anyKey)
        {
            myCollider.size = new Vector3(19.39f, 17.14f, 7.261f);
            myCollider.center = new Vector3(0, 0, 0);
        }

        //Teleport
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newknifeSpriteObj = Instantiate(carrotSprite);
            newknifeSpriteObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1f);
        }
        if (floorNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, 1f, 2.6f);
                floorNumber = 2;
            }
        }
        else if (floorNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, 3f, 7.6f);
                floorNumber = 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, -1f, 0f);
                floorNumber = 1;
            }
        }
        else if (floorNumber == 3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, 1f, 2.6f);
                floorNumber = 2;
            }
        }

        //Pause
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "floor")
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "boss attack")
        {
            health -= 1;
        }
    }

}
