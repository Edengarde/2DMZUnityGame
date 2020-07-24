using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        //Ataques
        if (playerController.inputScript.isSwordActive && !playerController.inputScript.isSwordBlocked)
        {
            SwordAttack();
        }
        else if (playerController.inputScript.isGunActive && !playerController.inputScript.isGunBlocked)
        {
            if (playerController.activeBullets < playerController.maxBullets)
            {
                PlayerShoot();
            }
        }
        else
        {
            //Resets states after no input
            playerController.animator.SetBool("isZpressed", false);
            playerController.animator.SetBool("isXpressed", false);
            playerController.isAttacking = false;
        }
    }

    private void SwordAttack()
    {
        //Maneja la hitbox del ataque con la espada
        playerController.animator.SetBool("isZpressed", true);
        playerController.isAttacking = true;
        playerController.swordAttackHitbox.SetActive(true);
    }

    private void PlayerShoot()
    {
        playerController.animator.SetBool("isXpressed", true);
        playerController.isAttacking = true;
        GameObject b = Instantiate(playerController.bullet);
        b.GetComponent<BulletScript>().StartShoot(playerController.isFacingLeft);
        b.transform.position = playerController.bulletSpawnPos.transform.position;
        playerController.activeBullets += 1;
    }


    //Functions used by Sword_Animation//

    //Disables the hitbox of the sword after the attack ends
    private void EndSwordAttack()
    {
        playerController.swordAttackHitbox.SetActive(false);
        playerController.isAttacking = false;
    }
    //Prevents the immediate use of your gun until the animation of the Sword ends
    private void UnblockGun()
    {
        playerController.inputScript.isGunBlocked = false;
    }

}
