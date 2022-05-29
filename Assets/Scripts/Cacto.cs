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
        float distance = Vector2.Distance(target.position, this.transform.position);
        if(distance <= 5)
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
