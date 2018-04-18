using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linelayer : MonoBehaviour {

    public GameObject rabbit;
    public GameObject floorLine;

    SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rabbit.GetComponent<movement>().floorNumber == 1)
        {
            mySpriteRenderer.color = new Color(0, 0, 0, .7f);
            transform.position = new Vector3(transform.position.x, transform.position.y, floorLine.transform.position.z);
        }
        else if (rabbit.GetComponent<movement>().floorNumber == 3)
        {
            mySpriteRenderer.color = new Color(0, 0, 0, .7f);
            transform.position = new Vector3(transform.position.x, transform.position.y, floorLine.transform.position.z);
        }
        else if (rabbit.GetComponent<movement>().floorNumber == 2)
        {
            mySpriteRenderer.color = new Color(1, 1, 1, 1);
            transform.position = new Vector3(transform.position.x, transform.position.y, floorLine.transform.position.z);
        }
    }
}
