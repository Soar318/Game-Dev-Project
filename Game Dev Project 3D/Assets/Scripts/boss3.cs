using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss3 : MonoBehaviour {

    public GameObject feather;
    public GameObject egg;
    public GameObject stick;
    public GameObject rabbit;
    public GameObject floorColor;
    public GameObject camera;
    public AudioClip explode;


    public Image healthBar;

    public int health = 30;
    public int attackCounter1;

    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    AudioSource myAudio;

    float pelletTimer = 1.5f;
    float waveTimer = 2f;
    float columnTimer = 4f;
    float idleTimer = 3f;
    public float attackCounterTimer1 = 5f;

    private bool isHurt = false;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pelletTimer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;
        columnTimer -= Time.deltaTime;
        idleTimer -= Time.deltaTime;
        attackCounterTimer1 -= Time.deltaTime;

        if (attackCounterTimer1 <= 0)
        {
            attackCounter1 = Random.Range(1, 4);
            attackCounterTimer1 = 5f;
        }

        if (attackCounter1 == 1)
        {
            if (pelletTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(feather);
                newbossAttack.transform.position = new Vector3(Random.Range(6f, 7f), Random.Range(-1f, 1f), floorColor.transform.position.z);
                pelletTimer = 1.5f;
            }
            myAnimator.Play("Boss 3 Attack");
        }
        if (attackCounter1 == 2)
        {
            if (waveTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(egg);
                newbossAttack.transform.position = new Vector3(transform.position.x, -.43f, floorColor.transform.position.z - 1);
                waveTimer = 2f;
            }
            myAnimator.Play("Boss 3 Attack");
        }
        if (attackCounter1 == 3)
        {
            if (columnTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(stick);
                newbossAttack.transform.position = new Vector3(Random.Range(-7f, 3f), 15f, floorColor.transform.position.z);
                columnTimer = 4f;
            }
            myAnimator.Play("Boss 3 Attack");
        }
        if (attackCounter1 == 4)
        {
            if (idleTimer <= 0)
            {
                idleTimer = 3f;
            }
            myAnimator.Play("Boss 3 Idle");
        }

        if (health <= 0)
        {
            myAudio.PlayOneShot(explode);
            mySpriteRenderer.enabled = false;
            healthBar.rectTransform.localScale = new Vector3(0, 0, 0);
            camera.GetComponent<camerashake>().camShake = true;
            Destroy(gameObject, explode.length);
        }

        if (rabbit.GetComponent<movement>().floorNumber == 1 || rabbit.GetComponent<movement>().floorNumber == 2)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, 0);
        }
        else if (rabbit.GetComponent<movement>().floorNumber == 3)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, 1);
        }

        if (isHurt == true)
        {
            mySpriteRenderer.color = new Color(1, 0, 0);
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "player attack" && rabbit.GetComponent<movement>().floorNumber == 3)
        {
            isHurt = true;
            health -= 1;
            healthBar.rectTransform.localScale -= new Vector3(.103f, 0, 0);
        }
        if (collisionInfo.gameObject.tag == "charge attack" && rabbit.GetComponent<movement>().floorNumber == 3)
        {
            isHurt = true;
            health -= 7;
            healthBar.rectTransform.localScale -= new Vector3(.721f, 0, 0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        mySpriteRenderer.color = new Color(1, 1, 1);
        isHurt = false;
    }
}
