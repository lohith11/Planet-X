using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    #region Singleton Class

    public static Player1 Instance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();

        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [Header("Player Movement")]

    public Rigidbody2D rb;
    public BoxCollider2D collide;
    public bool isGrounded = false;
    public Transform rayPoint;
    public float rayDistance = 2f;
    [SerializeField] bool fallDamage = false;
   
    [Header("Player Stats")]

    [Range(0.02f, 0.1f)]
    public float Damagemultiplier = 0.02f;
    public float health;
    public float Damage;
    public bool Dead = false;

    public Vector3 position
    {
        get
        {
            return transform.position;
        }
    }

    private void Update()
    {
        checkFallHeight();
        healthBar.healthInstance.setHealth(health);
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     health -= 100f;
        // }

        if(health <= 0)
        {
            //Time.timeScale = 0f;
            Dead = true;
        }
    }

    void checkFallHeight()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rayPoint.position.x, rayPoint.position.y), Vector2.down, rayDistance);
        if (hit.distance > 1 && !fallDamage && rb.velocity.y < -2f)
        {
            fallDamage = true;
        }
        

    }

    void dealDamage(Vector2 force)
    {
        float velocity = rb.velocity.magnitude;
        Damage = velocity * force.magnitude * Damagemultiplier ;
        Damage = Mathf.Clamp(Damage, 0, 100);
        Debug.Log("Damage : " + Damage);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Ground")
        {
            isGrounded = true;
            if (fallDamage)
            {
                fallDamage = false;
                health -= 100;
            }

        }

        if(other.collider.CompareTag("SmallBullet"))
        {
            Destroy(other.gameObject);
            health -= 80;
        }

    }
    
    public void push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        dealDamage(force);

    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DeactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = false;
    }


}



