using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public GameObject eye;
    public GameObject heart;

    public int health = 50;

    SpriteRenderer mySpriteRenderer;

    float pelletTimer = 1f;
    float waveTimer = 3f;
    public float attackCounterTimer = 5f;

    public int attackCounter;

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
        attackCounterTimer -= Time.deltaTime;

        if (attackCounterTimer <= 0)
        {
            attackCounter = Random.Range(1, 5);
            attackCounterTimer = 5f;
        }
        
        if (attackCounter == 1)
        {
            if (pelletTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(eye);
                newbossAttack.transform.position = new Vector3(Random.Range(6f, 7f), Random.Range(-1f, 1f), .03f);
                pelletTimer = 1f;
            }
        }
        if (attackCounter == 2)
        {
            if (waveTimer <= 0)
            {
                GameObject newbossAttack = Instantiate(heart);
                newbossAttack.transform.position = new Vector3(transform.position.x, -.55f, .03f);
                waveTimer = 3f;
            }
           
        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "player attack")
        {
            mySpriteRenderer.color = new Color(1, 0, 0);
            health -= 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        mySpriteRenderer.color = new Color(1, 1, 1);
    }
}
