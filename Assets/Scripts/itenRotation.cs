using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itenRotation : MonoBehaviour
{
    public bool moveUp = true;
    IEnumerator Revert()
    {
        yield return new WaitForSeconds(1.5f);
        moveUp = false;
        yield return new WaitForSeconds(1.5f);
        moveUp = true;
    }
    void Update()
    {
        if (moveUp)
        {
            StartCoroutine("Revert");
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f * Time.deltaTime);
        }
    }
}
