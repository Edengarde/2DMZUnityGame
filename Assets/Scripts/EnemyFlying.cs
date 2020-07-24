using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Canvas canvas;

    // Bullet attack variables
    [SerializeField]
    GameObject enemyBullet;

    [SerializeField]
    Transform bulletSpawnPos;

    [SerializeField]
    public int maxBullets = 5;

    public int activeBullets = 0;

    bool isAttacking = false;

    public bool isFacingLeft;

    //Aggro movement variables
    [SerializeField]
    Transform player;

    [SerializeField]
    float aggroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    //Receive damage variables
    bool isAttacked = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Distancia al jugador
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //Debug.Log(distToPlayer);
        if(distToPlayer <= aggroRange)
        {
            ChasePlayer();
            if (!isAttacking)
            {
                StartCoroutine(ShootTimerPlayer());
                ShootPlayer();
            }
        }
        else
        {
            StopChasingPlayer();
        }

        if (isAttacked)
        {
            StartCoroutine(DisplayLifeBar());
            isAttacked = false;
        }
    }

    void ShootPlayer()
    {
        GameObject b = Instantiate(enemyBullet);
        b.GetComponent<EnemyBulletScript>().DropBombs();
        b.transform.position = bulletSpawnPos.transform.position;
    }

    IEnumerator DisplayLifeBar()
    {
        //Maneja el tiempo en el que aparece la barra de vida del enemigo despues de ser golpeado
        yield return new WaitForSeconds(2f);
        canvas.gameObject.SetActive(false);
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            isFacingLeft = false;
            transform.localScale = new Vector3(-1, 1, 1);
            healthBar.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            isFacingLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
            healthBar.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    IEnumerator ShootTimerPlayer()
    {
        isAttacking = true;
        yield return new WaitForSeconds(3f);
        isAttacking = false;
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.name == "SwordAttackHitbox")
        {
            //Muestra la barra de vida del enemigo cuando es golpeado y le quita la vida correspondiente
            canvas.gameObject.SetActive(true);
            isAttacked = true;
            currentHealth -= GameObject.Find("player").GetComponent<PlayerController>().swordDamage;
            healthBar.SetHealth(currentHealth);
            Debug.Log("Hit registered");
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("bullet"))
        {
            //Muestra la barra de vida del enemigo cuando es golpeado y le quita la vida correspondiente
            canvas.gameObject.SetActive(true);
            isAttacked = true;
            currentHealth -= collision.gameObject.GetComponent<BulletScript>().damage;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
            Debug.Log("Bullet registered");
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
