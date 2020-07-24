using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOneSpot : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;
    public bool allowMovement;
    private void Update()
    {
        //Move right till you touch the waypoint and when you do stop and destroy all of this stuff
        if (allowMovement && !goal.GetComponent<ColliderSensor>().touched)
        {
            player.GetComponent<PlayerMovement>().MovePlayerRight();
            //Debug.Log("NOT TOUCHED");
        }
        else if (allowMovement && goal.GetComponent<ColliderSensor>().touched)
        {
            player.GetComponent<PlayerMovement>().StopPlayerMovement();
            allowMovement = false;
            //Debug.Log("BAD TOUCH");
            Destroy(goal);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            player.GetComponent<PlayerInput>().StopPlayerInput();
            allowMovement = true;
        }
    }
    

}
