using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    float xSpeed = 5f;
    float ySpeed = 10f;
    public int floorNumber = 1;
    public int health = 5;

    Rigidbody myRigidbody;

    private bool isJumping = false;
    private bool isMoving = false;

    public GameObject carrotSprite;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && isJumping != true)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, ySpeed);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
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
