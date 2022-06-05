using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float direction;
    private Vector3 faceRight;
    private Vector3 faceLeft;
    public ParticleSystem dustEffect;

    [SerializeField] private bool lockMove = false;

    public SpriteRenderer spritePlayer;

    public Animator animator;

    public GameObject bulletHUD;
    public GameObject batteryHUD;
    public GameObject flagCheck;
    public GameObject panelMenuPause;
    public GameObject pauseButton;

    //Pulo de altura variavel
    [Header("Pulo de altura variavel")]
    public bool isJumping;
    public float jumpSpeed = 4f;
    public float counterJump = 0.17f;

    [Header("Colisão com chao")]
    //Colisão com chao
    private bool isGrounded;
    private bool quicksandSinking;

    [Header("Vida do personagem")]
    //Vida do personagem
    public int playerHP = 10;

    private float selfTimeDamage = 0;
    [SerializeField] private bool vulnerable = true;

    [Header("Tiro do personagem")]
    public GameObject bullet; //bala
    public GameObject bulletEffect; //efeito de disparo
    private float selfTimeBullet = 0; //tempo entre tiros
    private bool canShoot = true; //pode atirar

    [Header("Hit")]
    public GameObject spark;

    private Vector3 spawnPoint = new Vector3(-17, -1, 0); //Posição inicial

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(-17, -1, 0);
        rb.GetComponent<Rigidbody2D>();
        rb.position = spawnPoint;

        //Espelhamento
        faceRight = transform.localScale;
        faceLeft = transform.localScale;
        faceLeft.x = faceLeft.x * -1;

        batteryHUD.GetComponent<BatteryHUD>().HPBattery(playerHP);
    }

    void Update()
    {
        SinkingInQuicksand();
        PlayerMovement();
        PlayerJump();
        AnimationController();
        PlayerMirror();
        DamageControl();
        CheckDeath();
        Shooter();
        Achievements();
        Pause();
    }

 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Afundando na areia
    void SinkingInQuicksand()
    {
        if (quicksandSinking)
        {
            rb.velocity = new Vector2(rb.velocity.x, -0.95f);
        }       
    }

    //Movimentação lateral do personagem
    void PlayerMovement()
    {
        if (!lockMove)
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
    }

    //Pulo do personagem
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded || quicksandSinking)
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
                if (quicksandSinking)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed / 4);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                }
            }
            else
            {
                isJumping = false;
            }
        }
    }

    //Controle de animações
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

        //Se cair do cenário, volta pro checkpoint e perde 1hp
        if (this.transform.position.y < -10) //"Morte"
        {
            this.transform.position = spawnPoint;
            playerHP--;
            batteryHUD.GetComponent<BatteryHUD>().HPBattery(playerHP);
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
        if (collision.gameObject.CompareTag("Ground")) //Chao
        {
            isGrounded = true;
            DustEffect();
        }

        if (collision.gameObject.CompareTag("checkPoint")) //Checkpoint
        {
            Checkpoint(collision);
        }

        if (collision.gameObject.CompareTag("Battery")) //Bateria = HP
        {
            if(playerHP < 5)
            {
                Destroy(collision.gameObject);
                playerHP++;
                batteryHUD.GetComponent<BatteryHUD>().HPBattery(playerHP);
            }
        }

        if (collision.gameObject.CompareTag("plataforma")) //Plataforma flutuante
        {
            if(rb.transform.position.y > collision.transform.position.y + 0.2f)
            {
                this.transform.parent = collision.transform;
                isGrounded = true;
                DustEffect();
            }
        }

        if (collision.gameObject.CompareTag("plataformaV2")) //Plataforma flutuante V2
        {
            if (rb.transform.position.y > collision.transform.position.y + 0.2f)
            {
                this.transform.parent = collision.transform;
                isGrounded = true;
                plataformaVerticalV2 plat = collision.gameObject.GetComponent<plataformaVerticalV2>();
                plat.SetWithPlayer(true);
                DustEffect();
            }
        }

        if (collision.gameObject.CompareTag("plataformaH2")) //Plataforma flutuante H2
        {
            if (rb.transform.position.y > collision.transform.position.y + 0.2f)
            {
                this.transform.parent = collision.transform;
                isGrounded = true;
                plataformaHorizontalV2 plat = collision.gameObject.GetComponent<plataformaHorizontalV2>();
                plat.SetWithPlayer(true);
                DustEffect();
            }
        }

        if (collision.gameObject.CompareTag("Quicksand")) //Areia movedica
        {
            quicksandSinking = true;
            Debug.Log("Colidiu com areia");
            speed /= 2;
        }

        if (collision.gameObject.CompareTag("TilemapForeground"))
        {
            Debug.Log("Entrou da terra");
            Tilemap tilemap = collision.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                tilemap.color = new Color(0.9176471f, 0.6156863f, 0.3490196f, 0.25f);
            }
            /*
            SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            }*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Saindo da colisao com...
    //Antes de mudar para Trigger estava:
    //private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Chao
        {
            isGrounded = false;
            DustEffect();
        }

        if (collision.gameObject.CompareTag("plataforma")) //Plataforma flutuante
        {
            this.transform.parent = null;
            isGrounded = false;
            DustEffect();
        }

        if (collision.gameObject.CompareTag("plataformaV2")) //Plataforma flutuante V2
        {
            this.transform.parent = null;
            isGrounded = false;
            plataformaVerticalV2 plat = collision.gameObject.GetComponent<plataformaVerticalV2>();
            plat.SetWithPlayer(false);
            DustEffect();
        }

        if (collision.gameObject.CompareTag("plataformaH2")) //Plataforma flutuante V2
        {
            this.transform.parent = null;
            isGrounded = false;
            plataformaHorizontalV2 plat = collision.gameObject.GetComponent<plataformaHorizontalV2>();
            plat.SetWithPlayer(false);
            DustEffect();
        }

        if (collision.gameObject.CompareTag("Quicksand")) //Areia movedica
        {
            quicksandSinking = false;
            Debug.Log("Saiu da areia");
            speed *= 2;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed/2);
        }

        if (collision.gameObject.CompareTag("TilemapForeground"))
        {
            Debug.Log("Saiu da terra");
            Tilemap tilemap = collision.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                tilemap.color = new Color(0.9176471f, 0.6156863f, 0.3490196f, 1.0f);
            }
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (vulnerable)
            {
                lockMove = true;
                KnockBack(collision);

                GameObject hitSpark = Instantiate(spark, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
                hitSpark.transform.parent = this.transform;

                Debug.Log("Perdeu vida");
                playerHP--;
                batteryHUD.GetComponent<BatteryHUD>().HPBattery(playerHP);
                vulnerable = false;
            }
      
        }

        /**/ //Inserir aqui colisão com Checkpoint e coletáveis

        /*if(collision.gameObject.CompareTag("disket"))
        {
            Checkpoint(collision);
        }*/
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
        if (selfTimeDamage > 0.2f)
        {
            lockMove = false;
        }
    }
    
    //Kncokback sofrido ao levar dano(move o personagem para cima e para trás do inimigo que causou dano)
    void KnockBack(Collision2D collision)
    {
        if(transform.position.x >= collision.transform.position.x)
        {
            direction = -1;
            rb.AddForce(new Vector2(10, 15), ForceMode2D.Impulse);
        }
        else
        {
            direction = 1;
            rb.AddForce(new Vector2(-10, 15), ForceMode2D.Impulse);
        }
        animator.SetBool("Damage", true);
        /*
        if(this.transform.localScale.x == 1)
        {
            rb.AddForce(new Vector2(-10, 15), ForceMode2D.Impulse);
            
        }
        if(this.transform.localScale.x == -1)
        {
            rb.AddForce(new Vector2(10, 15), ForceMode2D.Impulse);
        }
        */
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
                bulletHUD.GetComponent<BulletHUD>().BulletShoot();
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
            Destroy(bulletFired, 0.5f);
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
            Destroy(bulletFired, 0.5f);
        }     
    }

    //Temporzador de tiro
    void TimerBullet()
    {
        selfTimeBullet += Time.deltaTime;
        bulletHUD.GetComponent<BulletHUD>().BulletTimer();
        if (selfTimeBullet > 0.5f)
        {
            canShoot = true;
            selfTimeBullet = 0;
        }
    }

    //Ao colidir com checkpoint redefine o spawnPoint e destroi o disket
    void Checkpoint(Collider2D collision)
    {
        spawnPoint = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        GameObject flag = Instantiate(flagCheck, new Vector3(collision.transform.position.x, collision.transform.position.y - 1.02f, collision.transform.position.z), Quaternion.identity);
        Destroy(collision.gameObject);
        if (playerHP < 3)
        {
            playerHP = 3;
            batteryHUD.GetComponent<BatteryHUD>().HPBattery(playerHP);
        }
    }

    //Redefine os valores de vida e spawnPoint
    void GameOver()
    {
        spawnPoint = new Vector3(-17, -1, 0);
        playerHP = 3;
        SceneManager.LoadScene(0);
    }

    //Conquistas
    void Achievements()
    {
        //
    }

    //Aplica efeito de fumaça nos pés
    void DustEffect()
    {
        dustEffect.Play();

        //Caso for inserir um DustEffect nas costas a posição seria x = -0.407; y = 0.995.
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGrounded || quicksandSinking)
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    panelMenuPause.SetActive(true);
                    pauseButton.SetActive(false);

                }
                else if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    panelMenuPause.SetActive(false);
                    pauseButton.SetActive(true);
                }
            }
        }
    }
}
