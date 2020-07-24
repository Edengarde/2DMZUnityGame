using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    Enemy enemyController;

    Coroutine DispLifeBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(distToPlayer);
        if (enemyController.distToPlayer <= enemyController.aggroRange)
        {
            if (!enemyController.isAttacking)
            {
                StartCoroutine(ShootTimerPlayer());
                ShootPlayer();
            }
        }

        if (enemyController.isAttacked)
        {
            if (DispLifeBar != null)
            {
                StopCoroutine(DispLifeBar);
            }
            DispLifeBar = StartCoroutine(DisplayLifeBar());
            enemyController.isAttacked = false;
        }
    }

    void ShootPlayer()
    {
        GameObject b = Instantiate(enemyController.enemyBullet);
        if(enemyController.enemyAtkType == false)
        {
            b.GetComponent<EnemyBulletScript>().StartShoot(enemyController.isFacingLeft);
        }
        else
        {
            b.GetComponent<EnemyBulletScript>().DropBombs();
        }
        b.transform.position = enemyController.bulletSpawnPos.transform.position;
    }

    IEnumerator ShootTimerPlayer()
    {
        enemyController.isAttacking = true;
        yield return new WaitForSeconds(3f);
        enemyController.isAttacking = false;

    }
    IEnumerator DisplayLifeBar()
    {
        //Maneja el tiempo en el que aparece la barra de vida del enemigo despues de ser golpeado
        yield return new WaitForSeconds(4f);
        enemyController.canvas.gameObject.SetActive(false);
    }


}
