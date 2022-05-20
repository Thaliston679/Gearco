using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private float bulletSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + bulletSpeed, transform.position.y, transform.position.z);
    }

    public void bulletDirection(float directionB)
    {
        bulletSpeed = directionB;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Chao
        {
            //Destroi a bala
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy") //Inimigo
        {
            //Destroi o inimiho
            Destroy(collision.gameObject);
            //Destroi a bala
            Destroy(this.gameObject);
        }
    }
}
