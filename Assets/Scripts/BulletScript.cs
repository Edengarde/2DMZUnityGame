using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    public int damage;

    [SerializeField]
    public float timeToDestroy;

    public void StartShoot(bool isFacingLeft)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        if (isFacingLeft)
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(speed, 0);
        }

        Destroy(gameObject, timeToDestroy);

    }

    private void OnDestroy()
    {
        GameObject.Find("player").GetComponent<PlayerController>().activeBullets -= 1;
       // Debug.Log("Bullet deleted");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
         
    }

}
