using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeAndDeath : MonoBehaviour
{
    public int enemyHP;
    public GameObject smokeExplosion;
    private float selfTimeDamage = 0;
    private bool onDamage = false;

    Move2D move2D;

    private void Start()
    {
        move2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Move2D>();
    }

    void Update()
    {
        if(enemyHP <= 0)
        {
            GameObject explosion = Instantiate(smokeExplosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            move2D.SetDeadEnemies(move2D.GetDeadEnemies() + 1);
        }
        TimerDamage();
    }

    void TimerDamage()
    {
        if (selfTimeDamage < 1)
        {
            selfTimeDamage += Time.deltaTime;
        }
        if (onDamage)
        {
            if (selfTimeDamage > 0.2f)
            {
                SpriteRenderer img = gameObject.GetComponent<SpriteRenderer>();
                img.color = Color.white;

                selfTimeDamage = 0;

                onDamage = false;
            }
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

    public void SetSelfTimerDamage(float i)
    {
        selfTimeDamage = i;
    }

    public void SetOnDamage(bool i)
    {
        onDamage = i;
    }
}
