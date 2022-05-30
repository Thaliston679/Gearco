using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaVerticalV2 : MonoBehaviour
{
    private bool withPlayer = false;
    public float velPlat; //Velocidade da plataforma
    public Transform moveUp;
    public Transform moveDown;

    void FixedUpdate()
    {   
        Movement();
    }

    public void Movement()
    {
        if (withPlayer)
        {
            if (transform.position.y <= moveDown.transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + velPlat * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y <= moveDown.transform.position.y + 1 && transform.position.y >= moveUp.transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - velPlat * Time.deltaTime);
            }
        }
    }

    public void SetWithPlayer(bool w) 
    {
        withPlayer = w;
    }
}
