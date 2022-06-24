using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoison : MonoBehaviour
{
    public GameObject player;
    private Vector2 playerPos;
    private Vector3 playerPosT;
    public GameObject poisonImpact;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    public float speedRot;
    public float speedMov;

    public float rotationModifier;

    Vector2 newMove;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 vectorToTarget = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
        
        if (player.transform.position.x > transform.position.x) {
            spriteRenderer.flipX = true;
        }
        else{
            spriteRenderer.flipX = false;
        }
        
        //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRot);
        playerPos = new Vector3(player.transform.position.x -1f, player.transform.position.y + 1f, player.transform.position.z);
        playerPosT = new Vector3(player.transform.position.x - 1f, player.transform.position.y + 1f, player.transform.position.z);


    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            /// Concertar (Fazer com que mova até bater em certa direção ao invés de posição)
            newMove = Vector2.MoveTowards(this.transform.position, playerPos, speedMov * Time.deltaTime);
            rb.MovePosition(newMove);
            ///
            //rb.AddForce(newMove, ForceMode2D.Force);
            //transform.Translate(playerPosT * speedMov * Time.deltaTime);

            if (transform.position == playerPosT)
            {
                GameObject poisonImpactEffect = Instantiate(poisonImpact, transform.position, Quaternion.identity);
                Destroy(gameObject, 0.1f);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Chao
        {
            GameObject poisonImpactEffect = Instantiate(poisonImpact, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
        }

        if (collision.gameObject.tag == "Player") //Chao
        {
            GameObject poisonImpactEffect = Instantiate(poisonImpact, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
        }
    }

}
