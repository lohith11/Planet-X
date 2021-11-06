using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle : MonoBehaviour
{
    float bulletspeed = 5f;

    Rigidbody2D rb;

    Player1 target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player1>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletspeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player1"))
            {
            Debug.Log("Hit");
            Destroy(gameObject);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
