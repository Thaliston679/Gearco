using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float velCloud;
    public float distCloud;
    public Transform cam;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - velCloud, transform.position.y, transform.position.z);
        //transform.position = new Vector3(transform.position.x - (cam.position.x * velCloud), transform.position.y, transform.position.z);

        if (transform.position.x < cam.position.x - distCloud*2 || transform.position.x > cam.position.x + distCloud*4)
        {
            //float posY = Random.RandomRange(-20, -14);
            float distR = Random.Range(distCloud*2, distCloud * 4);
            transform.position = new Vector3(cam.position.x + distR, transform.position.y, transform.position.z);
        }
    }
}
