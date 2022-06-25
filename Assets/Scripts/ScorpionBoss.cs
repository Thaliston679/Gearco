using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBoss : MonoBehaviour
{
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
        target = GameObject.FindGameObjectWithTag("Player");
    }
    public void FlipX()
    {
        if (transform.position.x > target.transform.position.x && flipX)
        {
            flipX = false;
            //img.flipX = flipX;
            this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); 
        }
        else if (transform.position.x < target.transform.position.x && !flipX)
        {
            flipX = true;
            //img.flipX = flipX;
            this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1f);
        }
    }

    public void MeleeAtk()
    {
        if (!flipX)
        {
            Vector3 impactPos = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
            GameObject impact = Instantiate(impactEffect, impactPos, Quaternion.identity);
            SpriteRenderer spriteRenderer = impact.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
            Destroy(impact, 0.5f);
        }
        else if (flipX)
        {
            Vector3 impactPos = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
            GameObject impact = Instantiate(impactEffect, impactPos, Quaternion.identity);
            SpriteRenderer spriteRenderer = impact.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
            Destroy(impact, 0.5f);
        }


    }

    public void RangeAtk()
    {
        if (!flipX)
        {
            Vector3 poisonBulletPos = new Vector3(transform.position.x + 1.971f, transform.position.y + 2.642f, transform.position.z);
            GameObject poisonBulletI = Instantiate(poisonBullet, poisonBulletPos, Quaternion.identity);
        }
        else if (flipX)
        {
            Vector3 poisonBulletPos = new Vector3(transform.position.x - 1.971f, transform.position.y + 2.642f, transform.position.z);
            GameObject poisonBulletI = Instantiate(poisonBullet, poisonBulletPos, Quaternion.identity);
        }
    }
}
