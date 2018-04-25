using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public bool camShake = true;

    public float shakeDuration = .5f;

    public GameObject rabbit;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (camShake == true)
        {
            if (shakeDuration > 0)
            {
                transform.position = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), transform.position.z);
                shakeDuration -= Time.deltaTime;
            }
        }
        if (shakeDuration == 0)
        {
            camShake = false;
        }
        if (camShake == false)
        {
            transform.position = new Vector3 (0, 1, -10);
            shakeDuration = .5f;
        }
      
    }
}
