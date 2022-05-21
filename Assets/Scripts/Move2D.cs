using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float direction;
    private Vector3 faceRight;
    private Vector3 faceLeft;

    public SpriteRenderer spritePlayer;

    public Animator animator;

    //Pulo de altura variavel
    [Header("Pulo de altura variavel")]
    public bool isJumping;
    public float jumpSpeed = 4f;
    public float counterJump = 0.17f;

    [Header("Colisão com chao")]
    //Colisão com chao
    private bool isGrounded;

    [Header("Vida do personagem")]
    //Vida do personagem
    public int playerHP = 10;

    private float selfTimeDamage = 0;
    private bool vulnerable = true;

    [Header("Tiro do personagem")]
    public GameObject bullet; //bala
    public GameObject bulletEffect; //efeito de disparo
    private float selfTimeBullet = 0; //tempo entre tiros
    private bool canShoot = true; //pode atirar

    private Vector3 spawnPoint = new Vector3(-22, 2, 0); //Posição inicial

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(-22, 2, 0);
        rb.GetComponent<Rigidbody2D>();

        //Espelhamento
        faceRight = transform.localScale;
        faceLeft = transform.localScale;
        faceLeft.x = faceLeft.x * -1;
    }

    void Update()
    {
        PlayerMovement();
        PlayerJump();
        AnimationController();
        PlayerMirror();
        DamageControl();
        CheckDeath();
        Shooter();
    }

 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Movimentação lateral do personagem
    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            direction = 1;

            animator.SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            direction = -1;

            animator.SetBool("Running", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

            animator.SetBool("Running", false);
        }
    }

    //Pulo do personagem
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                isJumping = true;
            }

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            counterJump -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            counterJump = 0.17f;
        }

        //Aplicando pulo
        if (isJumping)
        {
            if (counterJump > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            {
                isJumping = false;
            }
        }
    }

    void AnimationController()
    {
        //Controlador de animacao de jump(pulo) e fall(queda)
        if (rb.velocity.y >= 1)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
            
        }

        if (rb.velocity.y <= -1)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        //Controla se o player está no chão ou não para evitar bug da animação de run e idle entre o fall e jump
        if (isGrounded)
        {
            animator.SetBool("IsFloor", true);
        }
        else
        {
            animator.SetBool("IsFloor", false);
        }

        if (this.transform.position.y < -10) //"Morte"
        {
            this.transform.position = new Vector3(-22, 2, 0);
        }
    }

    //Espelhamento do personagem
    void PlayerMirror()
    {       
        if (direction > 0)
        {
            transform.localScale = faceRight;
        }
        if (direction < 0)
        {
            transform.localScale = faceLeft;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //Entrando em colisao com...
    //Antes de mudar para Trigger estava:
    //private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Chao
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag.Equals("plataforma")) //Plataforma flutuante
        {
            this.transform.parent = collision.transform;
            isGrounded = true;
        }       
    }

    private void OnTriggerExit2D(Collider2D collision) //Saindo da colisao com...
    //Antes de mudar para Trigger estava:
    //private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Chao
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag.Equals("plataforma")) //Plataforma flutuante
        {
            this.transform.parent = null;
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Quicksand") //areia movediça
        {
            rb.gravityScale = 8;
        }
    }

    //Enquanto não estiver vulnerável, ativa temporizador de ivulnerábilidade
    void DamageControl()
    {
        if (!vulnerable)
        {
            TimerDamage();
        }
    }

    //Verifica colisão
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (vulnerable)
            {
                KnockBack();

                Debug.Log("Perdeu vida");
                playerHP--;
                vulnerable = false;
            }
      
        }

        if(collision.gameObject.tag == "disket")
        {
            Checkpoint(collision);
        }

        if (collision.gameObject.tag == "Quicksand") //areia movediça
        {
            Debug.Log("NaAreia");
            rb.gravityScale = 0;
        }
    }

    //Tmporizador de dano(Tempo invulnerável)
    void TimerDamage()
    {
        selfTimeDamage += Time.deltaTime;
        if(selfTimeDamage > 1f)
        {
            vulnerable = true;
            selfTimeDamage = 0;
        }
    }
    
    //Kncokback sofrido ao levar dano(move o personagem para cima e para trás do inimigo que causou dano)
    void KnockBack()
    {
        animator.SetBool("Damage", true);
        if(this.transform.localScale.x == 1)
        {
            rb.AddForce(new Vector2(-speed * 2, jumpSpeed), ForceMode2D.Impulse);
        }
        if(this.transform.localScale.x == -1)
        {
            rb.AddForce(new Vector2(speed * 2, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    //Caso a vida estiver abaixo de 0, transporta o Player para o spawnPoint(checkpoint) e redefine a vida
    void CheckDeath()
    {
        if(playerHP <= 0)
        {
            GameOver();
        }
    }

    //Ativa tiro ao pressionar o imput de tiro
    void Shooter()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                canShoot = false;
                Shoot();
            }
        }
        else
        {
            TimerBullet();
        }
    }

    //Lança a bala e destroi depois de 3 segundos
    void Shoot()
    {
        if(direction >= 0)
        {
            //Origem do ponto de disparo
            Vector3 pointBullet = new Vector3(transform.position.x + 0.94f, transform.position.y + 0.959f, transform.position.z);
            //Origem do ponto de efeito de disparo
            Vector3 pointBulletEffect = new Vector3(transform.position.x + 1.542f, transform.position.y + 0.96f, transform.position.z);

            //Instancia tiro
            GameObject bulletFired = Instantiate(bullet, pointBullet, Quaternion.identity);
            //Define direção da força aplicada
            bulletFired.GetComponent<BulletControl>().bulletDirection(0.1f);
            //Muda direção do tiro
            bulletFired.transform.eulerAngles = new Vector3(0, 0, 0);

            //Instancia efeito de disparo
            GameObject objBulletEffect = Instantiate(bulletEffect, pointBulletEffect, Quaternion.identity);
            //Muda direção do efeito de disparo
            objBulletEffect.transform.eulerAngles = new Vector3(0, 0, 0);

            //Destroi bala
            Destroy(bulletFired, 3f);
        }
        else
        {
            //Origem do ponto de disparo
            Vector3 pointBullet = new Vector3(transform.position.x - 0.94f, transform.position.y + 0.959f, transform.position.z);
            //Origem do ponto de efeito de disparo
            Vector3 pointBulletEffect = new Vector3(transform.position.x - 1.542f, transform.position.y + 0.96f, transform.position.z);

            //Instancia tiro
            GameObject bulletFired = Instantiate(bullet, pointBullet, Quaternion.identity);
            //Define direção da força aplicada
            bulletFired.GetComponent<BulletControl>().bulletDirection(-0.1f);
            //Muda direção do tiro
            bulletFired.transform.eulerAngles = new Vector3(0, 0, 180);

            //Instancia efeito de disparo
            GameObject objBulletEffect = Instantiate(bulletEffect, pointBulletEffect, Quaternion.identity);
            //Muda direção do efeito de disparo
            objBulletEffect.transform.eulerAngles = new Vector3(0, 0, 180);

            //Destroi bala
            Destroy(bulletFired, 3f);
        }     
    }

    //Temporzador de tiro
    void TimerBullet()
    {
        selfTimeBullet += Time.deltaTime;
        if (selfTimeBullet > 0.5f)
        {
            canShoot = true;
            selfTimeBullet = 0;
        }
    }

    //Ao colidir com checkpoint redefine o spawnPoint e destroi o disket
    void Checkpoint(Collision2D collision)
    {
        spawnPoint = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        Destroy(collision.gameObject);
    }

    //Redefine os valores de vida e spawnPoint
    void GameOver()
    {
        spawnPoint = new Vector3(-22, 2, 0);
        playerHP = 3;
        SceneManager.LoadScene(1);
    }
}
