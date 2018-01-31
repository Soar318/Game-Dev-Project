using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

    float xSpeed = 10f;
    Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        myRigidbody.velocity = new Vector2(xSpeed, 0);
    }
}
