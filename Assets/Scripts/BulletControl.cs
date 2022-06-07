using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private float bulletSpeed = 0;
    public GameObject bulletImpact;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + bulletSpeed * 5.5f, transform.position.y, transform.position.z);
    }

    public void bulletDirection(float directionB)
    {
        bulletSpeed = directionB;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Chao
        {
            GameObject objBulletEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            //Destroi a bala
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "plataforma") //Plataforma
        {
            GameObject objBulletEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            //Destroi a bala
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy") //Inimigo
        {
            // !!!!! - Todo inimigo DEVE TER o Script EnemyHpControl - !!!!!
            //Chama o script do inimigo que verifica e altera a vida
            EnemyLifeAndDeath EnemyHpControl = collision.gameObject.GetComponent<EnemyLifeAndDeath>();
            EnemyHpControl.SetEnemyHp(EnemyHpControl.GetEnemyHp()-1);
            if(EnemyHpControl.GetEnemyHp() >= 1)
            {
                SpriteRenderer img = collision.gameObject.GetComponent<SpriteRenderer>();
                img.color = Color.red;
            }
            

            //Destroi a bala
            GameObject objBulletEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
