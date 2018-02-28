using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss3 : MonoBehaviour {

    public GameObject feather;
    public GameObject egg;
    public GameObject stick;
    public GameObject rose;
    public GameObject tongue;

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
    void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update () {
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
                    GameObject newbossAttack = Instantiate(feather);
                    newbossAttack.transform.position = new Vector3(Random.Range(6f, 7f), Random.Range(2.2f, 4f), 7.6f);
                    pelletTimer = 1f;
                }
            }
            if (attackCounter1 == 2)
            {
                if (waveTimer <= 0)
                {
                    GameObject newbossAttack = Instantiate(egg);
                    newbossAttack.transform.position = new Vector3(transform.position.x, 3.2f, 7.6f);
                    waveTimer = 3f;
                }
            }
            if (attackCounter1 == 3)
            {
                if (columnTimer <= 0)
                {
                    GameObject newbossAttack = Instantiate(stick);
                    newbossAttack.transform.position = new Vector3(Random.Range(-7f, 3f), 12.45f, 6f);
                    columnTimer = 2f;
                }
            }
            if (attackCounter1 == 4)
            {
                if (ballTimer <= 0)
                {
                    GameObject newbossAttack = Instantiate(rose);
                    newbossAttack.transform.position = new Vector3(transform.position.x, 11f, 7.6f);
                    ballTimer = 3f;
                }
            }
            if (attackCounter1 == 5)
            {
                if (beamTimer <= 0)
                {
                    GameObject newbossAttack = Instantiate(tongue);
                    newbossAttack.transform.position = new Vector3(19.59f, 1.95f, 6.85f);
                    beamTimer = 3f;
                }

            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }
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
