using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject eye;
    public int health = 20;
    SpriteRenderer mySpriteRenderer;
    float timer = 1f;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject newbossAttack = Instantiate(eye);
            newbossAttack.transform.position = new Vector3(Random.Range(6f, 7f), Random.Range(-1f, 1f), .03f);
            timer = 1f;
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
