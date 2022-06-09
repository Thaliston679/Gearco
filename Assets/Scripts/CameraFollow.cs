using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 2.5f; // 0.125f sem Time.deltaTime, 2.5f com
    public float distX = 1.5f;

    public Vector3 offset;

    private void FixedUpdate()
    {
        bool directionR = target.GetComponent<Move2D>().GetCameraViewingSideRight();
        offset.x = directionR ? distX : -distX;
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

}
