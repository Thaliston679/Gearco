using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacto : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private bool aggressive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAggressive(bool a)
    {
        target = a;
    }
}
