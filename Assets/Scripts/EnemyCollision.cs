using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    Enemy enemyController;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSword"))
        {
            //Muestra la barra de vida del enemigo cuando es golpeado por la espada y le quita la vida correspondiente
            enemyController.canvas.gameObject.SetActive(true);
            enemyController.isAttacked = true;
            enemyController.currentHealth -= GameObject.Find("player").GetComponent<PlayerController>().swordDamage;
            enemyController.healthBar.SetHealth(enemyController.currentHealth);
            //Debug.Log("Hit registered");
            if (enemyController.currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("bullet"))
        {
            //Muestra la barra de vida del enemigo cuando es golpeado por una bala y le quita la vida correspondiente
            enemyController.canvas.gameObject.SetActive(true);
            enemyController.isAttacked = true;
            enemyController.currentHealth -= collision.gameObject.GetComponent<BulletScript>().damage;
            enemyController.healthBar.SetHealth(enemyController.currentHealth);
            Destroy(collision.gameObject);
            //Debug.Log("Bullet registered");
            if (enemyController.currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
