using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenMovement : MonoBehaviour
{
    public bool moveUp = true;

    IEnumerator Revert()
    {
        if (moveUp)
        {
            moveUp = false;
            Debug.Log("Move False");
        }
        else
        {
            moveUp = true;
            Debug.Log("Move True");
        }
        yield return 1f;
    }
    void Update()
    {
        Revert();
    }
}
