using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaHorizontal : MonoBehaviour
{
    private bool movingRight = true;

    public float velPlat = 3f; //Velocidade da plataforma
    public Transform moveRight;
    public Transform moveLeft;

    void Update()
    {
        if (transform.position.x < moveRight.position.x)
        {
            movingRight = true;
        }
        if (transform.position.x > moveLeft.position.x)
        {
            movingRight = false;
        }

        if (movingRight) //Move a plataforma para direita
        {
            transform.position = new Vector2(transform.position.x + velPlat * Time.deltaTime, transform.position.y);
        }
        else //Move a plataforma para esquerda
        {
            transform.position = new Vector2(transform.position.x - velPlat * Time.deltaTime, transform.position.y);
        }
    }
}
