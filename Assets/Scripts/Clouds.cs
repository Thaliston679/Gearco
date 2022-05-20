using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float velCloud;
    public float distCloud;
    public Transform cam;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + velCloud, transform.position.y, transform.position.z);

        if(transform.position.x < cam.position.x - distCloud)
        {
            transform.position = new Vector3(cam.position.x + distCloud, transform.position.y, transform.position.z);
        }
    }
}
