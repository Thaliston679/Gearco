using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBoss : MonoBehaviour
{
    private bool movingRight = true;
    public int speedBoss = 5;

    public GameObject target;
    public GameObject poisonBullet;
    public GameObject impactEffect;

    public GameObject forRight;
    public GameObject forLeft;
    private SpriteRenderer img;
    private bool flipX = false; 

    private void Start()
    {
        img = GetComponent<SpriteRenderer>();
    }
    public void FlipX()
    {
        if (transform.position.x > target.transform.position.x && flipX)
        {
            flipX = false;
            img.flipX = flipX;
        }
        else if (transform.position.x < target.transform.position.x && !flipX)
        {
            flipX = true;
            img.flipX = flipX;
        }
    }

    public void MeleeAtk()
    {
        if (!flipX)
        {
            Vector3 impactPos = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
            GameObject impact = Instantiate(impactEffect, impactPos, Quaternion.identity);
            SpriteRenderer spriteRenderer = impact.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
        }
        else if (flipX)
        {
            Vector3 impactPos = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
            GameObject impact = Instantiate(impactEffect, impactPos, Quaternion.identity);
            SpriteRenderer spriteRenderer = impact.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
        }


    }

    void RangeAtk()
    {

    }

    void MoveBoss()
    {

    }

    void IdleBoss()
    {

    }
}
