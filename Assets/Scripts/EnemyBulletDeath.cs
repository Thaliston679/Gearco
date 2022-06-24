using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDeath : MonoBehaviour
{
    public int enemyHP;
    public GameObject smokeExplosion;

    void Update()
    {
        if(enemyHP <= 0)
        {
            GameObject explosion = Instantiate(smokeExplosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    public void SetEnemyHp(int i)
    {
        enemyHP = i;
    }

    public int GetEnemyHp()
    {
        return enemyHP;
    }
}
