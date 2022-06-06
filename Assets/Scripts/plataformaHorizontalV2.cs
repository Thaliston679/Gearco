using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaHorizontalV2 : MonoBehaviour
{
    private bool withPlayer = false;
    public bool forRight;
    public float velPlat; //Velocidade da plataforma
    public Transform moveRight;
    public Transform moveLeft;

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if (withPlayer && !forRight)
        {
            if (transform.position.x >= moveRight.transform.position.x)
            {
                transform.position = new Vector2(transform.position.x - velPlat * Time.deltaTime, transform.position.y);
            }
        }
        else if(!withPlayer && !forRight)
        {
            if (transform.position.x >= moveRight.transform.position.x - 1 && transform.position.x <= moveLeft.transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + velPlat * Time.deltaTime, transform.position.y);
            }
        }



        if (withPlayer && forRight)
        {
            if (transform.position.x >= moveRight.transform.position.x - 1 && transform.position.x <= moveLeft.transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + velPlat * Time.deltaTime, transform.position.y);
            }
        }
        else if(!withPlayer && forRight)
        {
            if (transform.position.x >= moveRight.transform.position.x)
            {
                transform.position = new Vector2(transform.position.x - velPlat * Time.deltaTime, transform.position.y);
            }
        }
    }

    public void SetWithPlayer(bool w)
    {
        withPlayer = w;
    }
}
