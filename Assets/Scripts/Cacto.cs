using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacto : MonoBehaviour
{
    public Transform target;
    private bool aggressive = false;
    public Transform thornOrigin;
    public GameObject thornBulletPrefab;

    private void Start()
    {
        InvokeRepeating("ThornShoot",1,1);
    }
    void Update()
    {
        AreaAggro();
        
    }

    public void ThornShoot()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator.GetBool("Aggressive"))
        {           
            for (float i = 0; i < 210; i+= 30)
            {
                GameObject thornBullet = Instantiate(thornBulletPrefab, thornOrigin.transform.position, thornOrigin.transform.rotation);
                thornBullet.transform.eulerAngles = new Vector3(0, 0, i);
            }
            Debug.Log("IEnumTest");
        }
    }

    public void AreaAggro()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        Debug.Log(distance);

        if(distance <= 4.5f)
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
