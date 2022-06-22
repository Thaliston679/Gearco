using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoison : MonoBehaviour
{
    public GameObject player;
    public GameObject poisonImpact;

    Rigidbody2D rb;

    public float speedRot;
    public float speedMov;

    public float rotationModifier;

    Vector2 newMove;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRot);

        newMove = Vector2.MoveTowards(this.transform.position, player.transform.position, speedMov * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            
            rb.MovePosition(newMove);
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
