using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    void FixedUpdate()
    {
        CheckGroundedPlayer();
        if (!playerController.inputScript.blockMovement)
        {
            if (playerController.inputScript.isRightPressed)
            {
                MovePlayerRight();
            }
            else if (playerController.inputScript.isLeftPressed)
            {
                MovePlayerLeft();
            }
            else
            {
                StopPlayerMovement();
            }

            if (playerController.inputScript.isJumpPressed)
            {
                PlayerJump();
            }
        }

    }

    public void CheckGroundedPlayer()
    {
        if (Physics2D.Linecast(transform.position, playerController.groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
         Physics2D.Linecast(transform.position, playerController.groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
         Physics2D.Linecast(transform.position, playerController.groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            playerController.inputScript.isGrounded = true;
        }
        else
        {
            playerController.inputScript.isGrounded = false;
        }
    }
    public void MovePlayerRight()
    {
        playerController.rb2d.velocity = new Vector2(playerController.runSpeed, playerController.rb2d.velocity.y);
        transform.localScale = new Vector3(1, 1, 1);
        playerController.healthBar.transform.localScale = new Vector3(1, 1, 1);
        playerController.isFacingLeft = false;
    }

    public void MovePlayerLeft()
    {
        playerController.rb2d.velocity = new Vector2(-playerController.runSpeed, playerController.rb2d.velocity.y);
        transform.localScale = new Vector3(-1, 1, 1);
        playerController.healthBar.transform.localScale = new Vector3(-1, 1, 1);
        playerController.isFacingLeft = true;
    }

    public void StopPlayerMovement()
    {
        playerController.rb2d.velocity = new Vector2(0, playerController.rb2d.velocity.y);
    }

    public void PlayerJump()
    {
        playerController.rb2d.velocity = new Vector2(playerController.rb2d.velocity.x, playerController.jumpSpeed);
    }
}
