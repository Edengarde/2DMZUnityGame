using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    Coroutine dmgDelay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyHurtbox")
        {
            if (playerController.isAttacking)
            {

            }
            else
            {
                TakeDamage(10);
                //Debug.Log("Player Ate Shit");
            }

        }
        else if (collision.CompareTag("enemyBullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyBulletScript>().damage);
            Destroy(collision.gameObject);
            //Debug.Log("Player Took a hit");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyHurtbox")
        {
            if (playerController.isAttacking)
            {

            }
            else
            {
                if(dmgDelay == null)
                {
                    dmgDelay = StartCoroutine(DamageDelay());
                }
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "EnemyHurtbox")
        {
            StopAllCoroutines();
        }
    }

    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(1f);
        TakeDamage(10);
        dmgDelay = null;
    }
    void TakeDamage(int damage)
    {
        playerController.currentHealth -= damage;
        playerController.healthBar.SetHealth(playerController.currentHealth);
    }
}
