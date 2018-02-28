using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {

    public float xSpeed = 13f;
    public float ySpeed = 17f;
    public int floorNumber = 1;
    public int health = 5;
    public float chargeCounter = 0;
    public float attackCooldown = .5f;

    Rigidbody myRigidbody;
    BoxCollider myCollider;
    SpriteRenderer mySprite;

    private bool isJumping = false;
    private bool isMoving = false;
    private bool isPaused = false;
    private bool noHealth = false;

    public GameObject carrotSprite;
    public GameObject cabbageSprite;
    public GameObject floor1Background;
    public GameObject floor2Background;
    public GameObject floor3Background;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    public Text paused;
    public Text restart;
    public Text mainMenu;
    public Text youLost;
    public Text tryAgain;
    public Text quit;

    public Image healthBar;
    public Image chargeBar;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<BoxCollider>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

        //MOVEMENT
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
        }

        //JUMPING AND DUCKING
        /*if (Input.GetKey(KeyCode.UpArrow) && isJumping != true)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, ySpeed);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) && isJumping != true)
        {
            myCollider.size = new Vector3(19.39f, 5.5f, 7.261f);
            myCollider.center = new Vector3(0f, -4, 0f);
        }
        else if (Input.anyKey)
        {
            myCollider.size = new Vector3(19.39f, 11.01937f, 7.261f);
            myCollider.center = new Vector3(0, -2.544112f, 0);
        }*/

        //ATTACK
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject newcarrotSpriteObj = Instantiate(carrotSprite);
                newcarrotSpriteObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1f);
                attackCooldown = .5f;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            chargeCounter += Time.deltaTime;
            chargeBar.rectTransform.localScale += new Vector3(.0133f, 0, 0);
        }
        else
        {
            chargeCounter -= Time.deltaTime;
            chargeBar.rectTransform.localScale -= new Vector3(.0133f, 0, 0);
        }
        if (chargeCounter >= 3)
        {
            GameObject newcabbageSpriteObj = Instantiate(cabbageSprite);
            newcabbageSpriteObj.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1f);
            chargeCounter = 0;
            chargeBar.rectTransform.localScale = new Vector3(0, 0.3839271f, 2.249413f);
        }
        if (chargeCounter < 0 || Time.timeScale == 0)
        {
            chargeCounter = 0;
            chargeBar.rectTransform.localScale = new Vector3(0, 0.3839271f, 2.249413f);
        }

        //TELEPORT
        floor1Background.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        floor2Background.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        floor3Background.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        if (floorNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, 1f, 2.6f);
                floorNumber = 2;
            }
            floor1Background.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
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
            floor2Background.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else if (floorNumber == 3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, 1f, 2.6f);
                floorNumber = 2;
            }
            floor3Background.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        //PAUSE
        if (isPaused == true)
        {
            paused.color = new Color(1, 1, 1, 1);
            restart.color = new Color(1, 1, 1, 1);
            mainMenu.color = new Color(1, 1, 1, 1);
            Time.timeScale = 0;
        }
        else if (isPaused == false)
        {
            paused.color = new Color(1, 1, 1, 0);
            restart.color = new Color(1, 1, 1, 0);
            mainMenu.color = new Color(1, 1, 1, 0);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.P) && isPaused != true)
        {
            isPaused = true;
            Debug.Log("PAUSED");
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused != false)
        {
            isPaused = false;
            Debug.Log("PLAY");
        }

        if (Input.GetKey(KeyCode.E) && isPaused != false)
        {
            SceneManager.LoadScene("Game");
            isPaused = false;
        }
        if (Input.GetKey(KeyCode.Escape) && isPaused != false)
        {
            SceneManager.LoadScene("Start Menu");
            isPaused = false;
        }

        //YOU LOSE
        if (health <= 0)
        {
            noHealth = true;
        }
        if (noHealth == true)
        {
            youLost.color = new Color(1, 1, 1, 1);
            quit.color = new Color(1, 1, 1, 1);
            tryAgain.color = new Color(1, 1, 1, 1);
            Time.timeScale = 0;
        }
        else if (noHealth == false)
        {
            youLost.color = new Color(1, 1, 1, 0);
            quit.color = new Color(1, 1, 1, 0);
            tryAgain.color = new Color(1, 1, 1, 0);
        }
        if (Input.GetKey(KeyCode.E) && noHealth != false)
        {
            SceneManager.LoadScene("Game");
            noHealth = false;
        }
        if (Input.GetKey(KeyCode.Escape) && noHealth != false)
        {
            SceneManager.LoadScene("Start Menu");
            noHealth = false;
        }

        if (boss1 == null && boss2 == null && boss3 == null)
        {
            SceneManager.LoadScene("Win");
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
            mySprite.color = new Color(1, 0, 0);
            healthBar.rectTransform.localScale -= new Vector3(.6358f, 0, 0);
        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        mySprite.color = new Color(1, 1, 1);
    }

}
