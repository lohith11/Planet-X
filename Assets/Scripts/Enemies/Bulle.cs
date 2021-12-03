using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle : MonoBehaviour
{
    float bulletspeed = 5f;

    Rigidbody2D rb;

    Player1 target;
    Vector2 moveDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player1>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletspeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Player1.Instance.health -= 100;
        }

    }

    void Update()
    {
        
    }
}
