using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossImpacteffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float flipx = -1f;
    public float speed = 5.5f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flipx = spriteRenderer.flipX == true ? flipx = 1 : flipx = -1;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + flipx * speed, transform.position.y, transform.position.z);
    }
}
