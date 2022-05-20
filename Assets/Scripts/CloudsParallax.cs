using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsParallax : MonoBehaviour
{
    private Transform cam;
    public float moveY;
    private float startPos;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float posY = cam.transform.position.y * moveY;

        transform.position = new Vector3(startPos + distance, posY, transform.position.z);

    }
}
