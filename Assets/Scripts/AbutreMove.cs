using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbutreMove : MonoBehaviour
{
    private bool movingRight = true;

    public float velAbutre = 3f; //Velocidade do Abutre
    public Transform moveRight;
    public Transform moveLeft;
    private Vector3 faceRight;
    private Vector3 faceLeft;

    void Start()
    {
        //Espelhamento
        faceRight = transform.localScale;
        faceLeft = transform.localScale;
        faceRight.x = faceRight.x * -1;
    }

    // Update is called once per frame
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

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + velAbutre * Time.deltaTime, transform.position.y);
            transform.localScale = faceRight;
        }
        else
        {
            transform.position = new Vector2(transform.position.x - velAbutre * Time.deltaTime, transform.position.y);
            transform.localScale = faceLeft;
        }

    }
}
