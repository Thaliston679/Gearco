using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itenRotation : MonoBehaviour
{
    public bool moveUp = true;
    public float inclination;
    IEnumerator Revert()
    {
        yield return new WaitForSeconds(1.5f);
        moveUp = false;
        yield return new WaitForSeconds(1.5f);
        moveUp = true;
    }
    void FixedUpdate()
    {
        Debug.Log(transform.eulerAngles.z);
        if (moveUp)
        {
            StartCoroutine(Revert());

            if (transform.eulerAngles.z <= inclination)
            {
                transform.Rotate(0, 0, inclination * Time.deltaTime);
            }
        }
        else
        {
            if (transform.eulerAngles.z >= -inclination)
            {
                transform.Rotate(0, 0, -inclination * Time.deltaTime);
            }
        }

    }
}
