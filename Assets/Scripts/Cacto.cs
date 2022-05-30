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

    IEnumerator ThornShoot()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator.GetBool("Aggressive"))
        {
            /*
            Vector3 pointBullet = new Vector3(transform.position.x - 0.94f, transform.position.y + 0.959f, transform.position.z);
            GameObject bulletFired = Instantiate(bullet, pointBullet, Quaternion.identity);
            bulletFired.transform.eulerAngles = new Vector3(0, 0, 180);
            */



        }
        yield return new WaitForSecondsRealtime(1);
        ThornShoot();
    }

    public void AreaAggro()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        Debug.Log(distance);

        if(distance <= 4.5f)
        {
            SetAggressive(true);
            StartCoroutine(ThornShoot());
        }
        else
        {
            SetAggressive(false);
            StopCoroutine(ThornShoot());
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
