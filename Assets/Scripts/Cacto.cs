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
        StartCoroutine(ThornShoot());
    }
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
            GameObject thornBullet =  Instantiate(thornBulletPrefab, thornOrigin.transform.position, thornOrigin.transform.rotation);
            for (int i = -30; i < 210; i+= 30)
            {
                thornOrigin.transform.eulerAngles = new Vector3(0, 0, i);
            }


        }
        yield return new WaitForSecondsRealtime(2f);
        ThornShoot();
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
