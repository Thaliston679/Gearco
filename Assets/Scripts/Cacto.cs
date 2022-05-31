using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacto : MonoBehaviour
{
    public Transform target;
    private bool aggressive = false;
    private bool doShoot = false;
    public Transform thornOrigin;
    public GameObject thornBulletPrefab;

    void Update()
    {
        AreaAggro();
        if (aggressive && doShoot == false) {
            StartCoroutine("ThornShoot");
        }
    }

    IEnumerator ThornShoot()
    {
        doShoot = true;
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator.GetBool("Aggressive"))
        {           
            for (float i = -30; i < 211; i+= 30)
            {
                GameObject thornBullet = Instantiate(thornBulletPrefab, thornOrigin.transform.position, thornOrigin.transform.rotation);
                thornBullet.transform.eulerAngles = new Vector3(0, 0, i);
            }
            Debug.Log("IEnumTest");
        }
        yield return new WaitForSeconds(0.5f);
        doShoot=false;
    }

    public void AreaAggro()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        Debug.Log(distance);

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
