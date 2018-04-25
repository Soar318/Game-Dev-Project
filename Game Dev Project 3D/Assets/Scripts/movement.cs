using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {

    public float speed = 0.05f;
    public float xSpeed = 13f;
    public float ySpeed = 17f;
    public int floorNumber = 1;
    public float health = 5;
    public float chargeCounter = 0;
    public float attackCooldown = .5f;

    float deadCounter = .5f;

    public float pitchCounter = .1f;
    public float pitchDuration = .5f;

    Rigidbody myRigidbody;
    SpriteRenderer mySprite;
    Animator myAnimator;
    AudioSource myAudio;

    private bool isPaused = false;
    private bool noHealth = false;
    public bool camShake = false;
    public bool pitchChange = false;

    public GameObject carrotSketch;
    public GameObject carrotLine;
    public GameObject carrotColor;

    public GameObject cabbageSketch;
    public GameObject cabbageLine;
    public GameObject cabbageColor;

    public GameObject floor1Background;
    public GameObject floor2Background;
    public GameObject floor3Background;

    public GameObject floorSketch;
    public GameObject floorLine;
    public GameObject floorColor;

    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    public GameObject black;
    public GameObject camera;

    public Text paused;
    public Text restart;
    public Text mainMenu;
    public Text youLost;
    public Text tryAgain;
    public Text quit;

    public Image healthBar;
    public Image chargeBar;


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mySprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
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

        //CHARGE
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

        //TELEPORT
        floor1Background.transform.position = new Vector3(.1f, -13f, 8.15f);
        floor2Background.transform.position = new Vector3(.1f, -13f, 8.15f);
        floor3Background.transform.position = new Vector3(.1f, -13f, 8.15f);

        if (floorNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                floorNumber = 2;
            }
            floor1Background.transform.position = new Vector3(.1f, .73f, 8.15f);
            floorSketch.transform.position = new Vector3(-1.7025f, -3.22f, 0.86f);
            floorLine.transform.position = new Vector3(-1.7025f, -3.22f, 3.3f);
            floorColor.transform.position = new Vector3(-1.7025f, -3.22f, 6f);
            myAnimator.Play("Player Run Sketch");
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
            floor2Background.transform.position = new Vector3(.1f, .73f, 8.15f);
            floorSketch.transform.position = new Vector3(-1.7025f, -3.22f, -1.33f);
            floorLine.transform.position = new Vector3(-1.7025f, -3.22f, 0.86f);
            floorColor.transform.position = new Vector3(-1.7025f, -3.22f, 3.61f);
            myAnimator.Play("Player Run Line");
        }
        else if (floorNumber == 3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                floorNumber = 2;
            }
            floor3Background.transform.position = new Vector3(.1f, .73f, 8.15f);
            floorSketch.transform.position = new Vector3(-1.7025f, -3.22f, -2.67f);
            floorLine.transform.position = new Vector3(-1.7025f, -3.22f, -1f);
            floorColor.transform.position = new Vector3(-1.7025f, -3.22f, 0.86f);
            myAnimator.Play("Player Run Color");
        }

        //PAUSE
        if (isPaused == true)
        {
            black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, .5f);
            paused.color = new Color(1, 1, 1, 1);
            restart.color = new Color(1, 1, 1, 1);
            mainMenu.color = new Color(1, 1, 1, 1);
            Time.timeScale = 0;
            camera.GetComponent<camerashake>().camShake = false;
        }
        else if (isPaused == false)
        {
            black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            paused.color = new Color(1, 1, 1, 0);
            restart.color = new Color(1, 1, 1, 0);
            mainMenu.color = new Color(1, 1, 1, 0);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.P) && isPaused != true)
        {
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused != false)
        {
            isPaused = false;
        }

        if (Input.GetKey(KeyCode.E) && isPaused != false)
        {
            SceneManager.LoadScene("Game");
            isPaused = false;
        }
        if (Input.GetKey(KeyCode.Escape) && isPaused != false)
        {
            SceneManager.LoadScene("Start Menu");
            Time.timeScale = 1;
        }

        //YOU LOSE
        if (health <= 0)
        {
            noHealth = true;
        }
        if (noHealth == true)
        {
            black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, .5f);
            youLost.color = new Color(1, 1, 1, 1);
            quit.color = new Color(1, 1, 1, 1);
            tryAgain.color = new Color(1, 1, 1, 1);
            Time.timeScale = 0;
            camera.GetComponent<camerashake>().camShake = false;
        }
        else if (noHealth == false)
        {
            black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
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

        //YOU WIN
        if (boss1 == null && boss2 == null && boss3 == null)
        {
            SceneManager.LoadScene("Win");
            camera.GetComponent<camerashake>().camShake = false;
        }
        if (boss1 == null || boss2 == null || boss3 == null)
        {
            deadCounter -= Time.deltaTime;
        }
        if (deadCounter < 0)
        {
            camera.GetComponent<camerashake>().camShake = false;
            deadCounter = .5f;
        }

        //MUSIC CHANGE
        if (pitchChange == true)
        {
            pitchDuration -= Time.deltaTime;
            if (pitchDuration < 0)
            {
                pitchChange = false;
                pitchDuration = .5f;
            }

            pitchCounter -= Time.deltaTime;
            if (pitchCounter > 0)
            {
                myAudio.pitch = Random.value;
            }
            if (pitchCounter < 0)
            {
                pitchCounter = .1f;
            }
        }
        if (pitchChange == false)
        {
            myAudio.pitch = 1;
        }
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "sketch attack" && floorNumber == 1)
        {
            health -= 1;
            mySprite.color = new Color(1, 0, 0);
            healthBar.rectTransform.localScale -= new Vector3(.6358f, 0, 0);
            camera.GetComponent<camerashake>().camShake = true;
            pitchChange = true;
           
        }
        if (collisionInfo.gameObject.tag == "line attack" && floorNumber == 2)
        {
            health -= 1;
            mySprite.color = new Color(1, 0, 0);
            healthBar.rectTransform.localScale -= new Vector3(.6358f, 0, 0);
            camera.GetComponent<camerashake>().camShake = true;
            pitchChange = true;

        }
        if (collisionInfo.gameObject.tag == "color attack" && floorNumber == 3)
        {
            health -= 1;
            mySprite.color = new Color(1, 0, 0);
            healthBar.rectTransform.localScale -= new Vector3(.6358f, 0, 0);
            camera.GetComponent<camerashake>().camShake = true;
            pitchChange = true;

        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        mySprite.color = new Color(1, 1, 1);
        camera.GetComponent<camerashake>().camShake = false;
    }

}