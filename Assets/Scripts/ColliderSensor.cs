﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSensor : MonoBehaviour
{
    public bool touched;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            touched = true;
            //Debug.Log("Touched");
        }
       
    }

}
