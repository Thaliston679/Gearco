using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacto : MonoBehaviour
{
    public Transform target;
    private bool aggressive = false;

    void Update()
    {
        AreaAggro();
    }

    public void AreaAggro()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        Debug.Log(distance);

        if(distance <= 3)
        {
            SetAggressive(true);
        }
        else
        {
            SetAggressive(false);
        }
    }

    public void SetAggressive(bool a)
    {
        aggressive = a;
    }

    public bool GetAggressive()
    {
        return aggressive;
    }
}
