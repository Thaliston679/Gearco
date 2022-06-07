using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itenRotation : MonoBehaviour
{
    public bool moveLeft = true;
    public float inclination;
    IEnumerator Revert()
    {
        yield return new WaitForSeconds(1.5f);
        moveLeft = false;
        yield return new WaitForSeconds(1.5f);
        moveLeft = true;
    }
    void FixedUpdate()
    {
        if (moveLeft)
        {
            StartCoroutine(Revert());
            transform.Rotate(0, 0, inclination * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -inclination * Time.deltaTime);
        }
        //Depois de alguns minutos, inclina demais para um lado
    }
}
