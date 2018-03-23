using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss2 : MonoBehaviour {

    public GameObject hairball;
    public GameObject rat;
    public GameObject paw;
    public GameObject tongue;
    public GameObject rabbit;

    public Image healthBar;

    public int health = 50;

    SpriteRenderer mySpriteRenderer;

    float pelletTimer = 1f;
    float waveTimer = 3f;
    float columnTimer = 2f;
    float idleTimer = 3f;
    float beamTimer = 3f;
    public float attackCounterTimer1 = 5f;

    public int attackCounter1;

    // Use this for initialization
    void Start ()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        pelletTimer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;
        columnTimer -= Time.deltaTime;
        idleTimer -= Time.deltaTime;
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
                GameObject newbossAttack = Instantiate(hairball);
                newbossAttack.transform.position = new Vector3(Random.Range(6f, 7f), Random.Range(0f, 2.5f), 2.6f);
                pelletTimer = 1f;
            }
        }
        if (attackCounter1 == 2)
        {
            if (waveTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(rat);
                newbossAttack.transform.position = new Vector3(transform.position.x, .49f, 2.6f);
                waveTimer = 3f;
            }
        }
        if (attackCounter1 == 3)
        {
            if (columnTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(paw);
                newbossAttack.transform.position = new Vector3(Random.Range(-7f, 3f), 12.45f, 1.8f);
                columnTimer = 2f;
            }
        }
        if (attackCounter1 == 4)
        {
            if (idleTimer <= 0)
            {
                idleTimer = 3f;
            }
        }
        if (attackCounter1 == 5)
        {
            if (beamTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(tongue);
                newbossAttack.transform.position = new Vector3(16.53f, -.65f, 1.93f);
                beamTimer = 3f;
            }

        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (rabbit.GetComponent<movement>().floorNumber == 2)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, 1);
            hairball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            rat.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            paw.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            tongue.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else if (rabbit.GetComponent<movement>().floorNumber == 1 || rabbit.GetComponent<movement>().floorNumber == 3)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, .3f);
            hairball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            rat.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            paw.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
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
