using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private float bulletSpeed = 0;
    public GameObject bulletImpact;
    private GameObject enemyC;

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
                EnemyHpControl.SetSelfTimerDamage(0);
                EnemyHpControl.SetOnDamage(true);
            }

            //Destroi a bala
            GameObject objBulletEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet") //Inimigo tiro
        {
            EnemyBulletDeath enemyBullet = collision.gameObject.GetComponent<EnemyBulletDeath>();
            enemyBullet.SetEnemyHp(enemyBullet.GetEnemyHp() - 1);
            //Destroi a bala
            GameObject objBulletEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Boss") //Boss
        {
            EnemyBossLifeAndDeath enemyBossLifeAndDeath = collision.gameObject.GetComponent<EnemyBossLifeAndDeath>();
            enemyBossLifeAndDeath.SetEnemyHp(enemyBossLifeAndDeath.GetEnemyHp() - 1);
            if (enemyBossLifeAndDeath.GetEnemyHp() >= 1)
            {
                SpriteRenderer img = collision.gameObject.GetComponent<SpriteRenderer>();
                img.color = Color.red;
                enemyBossLifeAndDeath.SetSelfTimerDamage(0);
                enemyBossLifeAndDeath.SetOnDamage(true);
            }

            //Destroi a bala
            GameObject objBulletEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    public void SetCollision2D(GameObject collision)
    {
        enemyC = collision;
    }

    public GameObject GetCollision2D()
    {
        return enemyC;
    }
}
