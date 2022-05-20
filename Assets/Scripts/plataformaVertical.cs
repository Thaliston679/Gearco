using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaVertical : MonoBehaviour
{
    private bool movingUp = true;

    public float velPlat = 3f; //Velocidade da plataforma
    public Transform moveUp;
    public Transform moveDown;

    void Update()
    {
        if (transform.position.y < moveUp.position.y)
        {
            movingUp = true;
        }
        if (transform.position.y > moveDown.position.y)
        {
            movingUp = false;
        }

        if (movingUp) //Move a plataforma para cima
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velPlat * Time.deltaTime);
        }
        else //Move a plataforma para baixo
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velPlat * Time.deltaTime);
        }
    }
}
