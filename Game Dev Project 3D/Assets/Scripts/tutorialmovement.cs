using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialmovement : MonoBehaviour
{

    public float speed = 0.05f;
    public float xSpeed = 13f;
    public float ySpeed = 17f;
    public int floorNumber = 1;
    public float chargeCounter = 0;
    public float attackCooldown = .5f;

    float waveTimer = 4f;

    Rigidbody myRigidbody;
    SpriteRenderer mySprite;
    Animator myAnimator;

    public GameObject carrotSketch;
    public GameObject carrotLine;
    public GameObject carrotColor;

    public GameObject cabbageSketch;
    public GameObject cabbageLine;
    public GameObject cabbageColor;

    public GameObject floorSketch;
    public GameObject floorLine;
    public GameObject floorColor;

    public GameObject heartSketch;

    public Image chargeBar;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mySprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //MOVEMENT
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
        }

        //ATTACK
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && floorNumber == 1)
            {
                GameObject newcarrotSketchObj = Instantiate(carrotSketch);
                newcarrotSketchObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1f);
                attackCooldown = .5f;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && floorNumber == 2)
            {
                GameObject newcarrotLineObj = Instantiate(carrotLine);
                newcarrotLineObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1f);
                attackCooldown = .5f;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && floorNumber == 3)
            {
                GameObject newcarrotColorObj = Instantiate(carrotColor);
                newcarrotColorObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1f);
                attackCooldown = .5f;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && (!Input.GetKey(KeyCode.Space)))
        {
            chargeCounter += Time.deltaTime;
            chargeBar.rectTransform.localScale += new Vector3(.0133f, 0, 0);
        }
        else
        {
            chargeCounter -= Time.deltaTime;
            chargeBar.rectTransform.localScale -= new Vector3(.0133f, 0, 0);
        }
        if (chargeCounter >= 3 && floorNumber == 1)
        {
            GameObject newcabbageSketchObj = Instantiate(cabbageSketch);
            newcabbageSketchObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y + 1f, transform.position.z - 1f);
            chargeCounter = 0;
            chargeBar.rectTransform.localScale = new Vector3(0, 0.3839271f, 2.249413f);
        }
        else if (chargeCounter >= 3 && floorNumber == 2)
        {
            GameObject newcabbageLineObj = Instantiate(cabbageLine);
            newcabbageLineObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y + 1f, transform.position.z - 1f);
            chargeCounter = 0;
            chargeBar.rectTransform.localScale = new Vector3(0, 0.3839271f, 2.249413f);
        }
        else if (chargeCounter >= 3 && floorNumber == 3)
        {
            GameObject newcabbageColorObj = Instantiate(cabbageColor);
            newcabbageColorObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y + 1f, transform.position.z - 1f);
            chargeCounter = 0;
            chargeBar.rectTransform.localScale = new Vector3(0, 0.3839271f, 2.249413f);
        }
        if (chargeCounter < 0 || Time.timeScale == 0)
        {
            chargeCounter = 0;
            chargeBar.rectTransform.localScale = new Vector3(0, 0.3839271f, 2.249413f);
        }

        waveTimer -= Time.deltaTime;

        //TELEPORT
        if (floorNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                floorNumber = 2;
            }
            floorSketch.transform.position = new Vector3(-.2179f, -2.02f, -3.0317f);
            floorLine.transform.position = new Vector3(-0, -1.76f, -2.3229f);
            floorColor.transform.position = new Vector3(0, -1.5016f, -1.5403f);
            myAnimator.Play("Player Run Sketch");

            if (waveTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(heartSketch);
                newbossAttack.transform.position = new Vector3(10f, 0, -3.3f);
                waveTimer = 4f;
            }
        }
        else if (floorNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                floorNumber = 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                floorNumber = 1;
            }
            floorSketch.transform.position = new Vector3(-.2179f, -2.24f, -3.87f);
            floorLine.transform.position = new Vector3(-.2179f, -2.02f, -3.0317f);
            floorColor.transform.position = new Vector3(-0, -1.76f, -2.3229f);
            myAnimator.Play("Player Run Line");
        }
        else if (floorNumber == 3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                floorNumber = 2;
            }
            floorSketch.transform.position = new Vector3(-.2179f, -2.2f, -5.64f);
            floorLine.transform.position = new Vector3(-.2179f, -2.24f, -4.37f);
            floorColor.transform.position = new Vector3(-.2179f, -2.24f, -3.0317f);
        }
    }


    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "sketch attack" && floorNumber == 1)
        {
            mySprite.color = new Color(1, 0, 0);
        }
        if (collisionInfo.gameObject.tag == "line attack" && floorNumber == 2)
        {
            mySprite.color = new Color(1, 0, 0);
        }
        if (collisionInfo.gameObject.tag == "color attack" && floorNumber == 3)
        {
            mySprite.color = new Color(1, 0, 0);
        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        mySprite.color = new Color(1, 1, 1);
    }
}
