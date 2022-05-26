using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaVerticalV2 : MonoBehaviour
{
    private bool movingUp = true;
    private bool withPlayer = false;
    public float velPlat = 3f; //Velocidade da plataforma
    public Transform moveUp;
    public Transform moveDown;

    void Update()
    {   
        Movement();
    }

    public void Movement()
    {
        if (transform.position.y < moveUp.position.y)
        {
            if (withPlayer)
            {
                movingUp = true;
            }
        }
        if (transform.position.y > moveDown.position.y)
        {
            movingUp = false;
        }

        if (movingUp && withPlayer) //Move a plataforma para cima
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velPlat * Time.deltaTime);
        }
        else if (!movingUp) //Move a plataforma para baixo
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velPlat * Time.deltaTime);
        }
    }

    public void SetWithPlayer(bool w) 
    {
        withPlayer = w;
    }


}