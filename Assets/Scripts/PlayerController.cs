﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Player subscripts references//
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    internal PlayerInput inputScript;

    [SerializeField]
    internal PlayerMovement movementScript;

    [SerializeField]
    internal PlayerAttacks attackScript;

    [SerializeField]
    internal PlayerCollision collisionScript;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Player Properties//
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public Rigidbody2D rb2d; //Player rigidbody

    public Animator animator; //Player Animator
   
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Player Health //
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    [SerializeField]
    public HealthBar healthBar;  //Player HealthBar

    public int maxHealth = 100;
    
    public int currentHealth;
    
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Player Movement
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    [SerializeField]
    public float runSpeed = 1.5f;

    [SerializeField]
    public float jumpSpeed = 4f;

    public bool isFacingLeft;  //Used by BulletScript.cs to determine direction of bullets, could be done better

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Player Input//
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    public Transform groundCheck;

    [SerializeField]
    public Transform groundCheckL;

    [SerializeField]
    public Transform groundCheckR;

    [SerializeField]
    public Transform ceilingCheck;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Sword attack properties//
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    public GameObject swordAttackHitbox;  

    [SerializeField]
    public int swordDamage;

    public bool isAttacking = false;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Bullets data//
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    public GameObject bullet;

    [SerializeField]
    public Transform bulletSpawnPos;

    [SerializeField]
    public int maxBullets = 5;

    public int activeBullets = 0;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        swordAttackHitbox.SetActive(false);
        currentHealth = maxHealth;
    }

    private void Update()
    {

    }

}