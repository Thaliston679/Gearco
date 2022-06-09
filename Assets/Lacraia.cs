using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lacraia : MonoBehaviour
{
    public Transform topLimit;
    public Transform botLimit;
    public GameObject lacraia;
    public Animator animator;
    private bool actived = false;
    public Transform target;
    private float distance;

    private void Start()
    {
        lacraia.transform.position = new Vector3(botLimit.position.x, botLimit.position.y, botLimit.transform.position.z);
    }

    private void Update()
    {
        //Calcula distancia entre a lacraia e o player
        distance = Vector2.Distance(target.position, lacraia.transform.position);

        //Ativa ou desativa a lacraia
        if(distance <= 5)
        {
            actived = true;
        }
        else
        {
            actived = false;
        }

        //Move a lacraia para cima e para baixo dependendo da distancia entre ela e o player
        if (actived && (lacraia.transform.position != topLimit.transform.position))
        {
            lacraia.transform.position = Vector3.Lerp(lacraia.transform.position, topLimit.transform.position, 0.05f);
        }
        else if(!actived && (lacraia.transform.position != botLimit.transform.position))
        {
            lacraia.transform.position = Vector3.Lerp(lacraia.transform.position, botLimit.transform.position, 0.05f);
        }

        //Chama animações
        if(actived && lacraia.transform.position.y >= topLimit.position.y - 0.5f)
        {
            animator.SetBool("actived", true);
        }
        else
        {
            animator.SetBool("actived", false);
        }
    }

}
