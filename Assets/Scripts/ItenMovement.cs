using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenMovement : MonoBehaviour
{
    public bool moveUp = true;
    IEnumerator Revert()
    {
        yield return new WaitForSeconds(0.5f);
        moveUp = false;
        yield return new WaitForSeconds(0.5f);
        moveUp = true;
    }
    void Update()
    {
        if (moveUp)
        {
            StartCoroutine("Revert");
            transform.position = new Vector2(transform.position.x, transform.position.y + 1 * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1 * Time.deltaTime);
        }
    }
}
