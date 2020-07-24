using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Enemy enemyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Debug.Log(distToPlayer);
        if(enemyController.enemyMovType == true)
        {
            if (enemyController.distToPlayer <= enemyController.aggroRange)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
            }
        }
        else
        {

        }


    }

    void ChasePlayer()
    {
        //Debug.Log(transform.position.x - player.position.x);
        if (transform.position.x < enemyController.player.position.x)
        {
            MoveRight();
        }
        else if (transform.position.x > enemyController.player.position.x)
        {
            MoveLeft();
        }
        if (Physics2D.Linecast(transform.position, enemyController.wallDetector.position, 1 << LayerMask.NameToLayer("Terrain")))
        {
            StopChasingPlayer();
        }
    }

    void MoveRight()
    {
        enemyController.rb2d.velocity = new Vector2(enemyController.moveSpeed, 0);
        enemyController.isFacingLeft = false;
        transform.localScale = new Vector3(-1, 1, 1);
        enemyController.healthBar.transform.localScale = new Vector3(-1, 1, 1);
    }

    void MoveLeft()
    {
        enemyController.rb2d.velocity = new Vector2(-enemyController.moveSpeed, 0);
        enemyController.isFacingLeft = true;
        transform.localScale = new Vector3(1, 1, 1);
        enemyController.healthBar.transform.localScale = new Vector3(1, 1, 1);
    }

    void StopChasingPlayer()
    {
        enemyController.rb2d.velocity = new Vector2(0, 0);
    }

   
}
