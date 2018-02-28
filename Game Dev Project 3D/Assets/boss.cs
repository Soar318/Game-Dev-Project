using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public GameObject eye;
    public GameObject heart;
    public GameObject bone;
    public GameObject skull;
    public GameObject tongue;
    public GameObject rabbit;

    public Image healthBar;

    public int health = 50;

    SpriteRenderer mySpriteRenderer;

    float pelletTimer = 1f;
    float waveTimer = 3f;
    float columnTimer = 2f;
    float ballTimer = 3f;
    float beamTimer = 3f;
    public float attackCounterTimer1 = 5f;

    public int attackCounter1;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        pelletTimer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;
        columnTimer -= Time.deltaTime;
        ballTimer -= Time.deltaTime;
        beamTimer -= Time.deltaTime;
        attackCounterTimer1 -= Time.deltaTime;

        if (attackCounterTimer1 <= 0)
        {
            attackCounter1 = Random.Range(1, 5);
            attackCounterTimer1 = 5f;
        }
        
        if (attackCounter1 == 1)
        {
            if (pelletTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(eye);
                newbossAttack.transform.position = new Vector3(Random.Range(6f, 7f), Random.Range(-1f, 1f), .03f);
                pelletTimer = 1f;
            }
        }
        if (attackCounter1 == 2)
        {
            if (waveTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(heart);
                newbossAttack.transform.position = new Vector3(transform.position.x, -1f, .03f);
                waveTimer = 3f;
            }
        }
        if (attackCounter1 == 3)
        {
            if (columnTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(bone);
                newbossAttack.transform.position = new Vector3(Random.Range(-7f, 3f), 12.45f, -1.12f);
                columnTimer = 2f;
            }         
        }
        if (attackCounter1 == 4)
        {
            if (ballTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(skull);
                newbossAttack.transform.position = new Vector3(transform.position.x, 8.92f, -.44f);
                ballTimer = 3f;
            }
        }
        if (attackCounter1 == 5)
        {
            if (beamTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(tongue);
                newbossAttack.transform.position = new Vector3(17.75f, -.73f, -.54f);
                beamTimer = 3f;
            }
            
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (rabbit.GetComponent<movement>().floorNumber == 1)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, 1);
            eye.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            heart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            skull.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            bone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            tongue.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else if (rabbit.GetComponent<movement>().floorNumber == 2 || rabbit.GetComponent<movement>().floorNumber == 3)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, .3f);
            eye.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            heart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            skull.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            bone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            tongue.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
        }
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "player attack")
        {
            mySpriteRenderer.color = new Color(1, 0, 0);
            health -= 1;
            healthBar.rectTransform.localScale -= new Vector3(.06f, 0, 0);
        }
        if (collisionInfo.gameObject.tag == "charge attack")
        {
            mySpriteRenderer.color = new Color(1, 0, 0);
            health -= 5;
            healthBar.rectTransform.localScale -= new Vector3(.3f, 0, 0);
        }
    }


    void OnTriggerExit(Collider other)
    {
        mySpriteRenderer.color = new Color(1, 1, 1);
    }
}
