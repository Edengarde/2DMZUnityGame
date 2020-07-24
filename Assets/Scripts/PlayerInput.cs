using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isJumpPressed;
    internal bool isGrounded;
    internal bool isSwordActive;
    internal bool isGunActive;
    internal bool isSwordBlocked;
    internal bool isGunBlocked;
    public bool blockMovement;
    public bool blockAttacks;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        if(blockAttacks == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isSwordActive = true;
                isGunActive = false;
                isGunBlocked = true;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                isGunActive = true;
                isSwordActive = false;
            }
            else
            {
                isSwordActive = false;
                isGunActive = false;
            }
        }
        else
        {
            isSwordActive = false;
            isGunActive = false;
        }
        
    }

    private void FixedUpdate()
    {
     
        //Movimientos 
        if(blockMovement == false)
        {
            if (Input.GetKey("right"))
            {
                isLeftPressed = false;
                isRightPressed = true;
            }
            else if (Input.GetKey("left"))
            {
                isLeftPressed = true;
                isRightPressed = false;
            }
            else
            {
                isLeftPressed = false;
                isRightPressed = false;
            }

            if (Input.GetKey("space") && isGrounded)
            {
                isJumpPressed = true;
            }
            else
            {
                isJumpPressed = false;
            }
        }
        else
        {
            isLeftPressed = false;
            isRightPressed = false;
            isJumpPressed = false;
        }
        
    }

    public void StopPlayerInput()
    {
        blockAttacks = true;
        blockMovement = true;
    }

    public void ResumePlayerInput()
    {
        blockAttacks = false;
        blockMovement = false;
    }
}
