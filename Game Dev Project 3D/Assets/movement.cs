using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    float xSpeed = 5f;
    float ySpeed = 10f;

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
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(0, 1.7f, 2.55f);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "floor")
        {
            isJumping = false;
        }
    }

}
