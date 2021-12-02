using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float DamageTaken;

    
    void Start()
    {
        
    }


    void Update()
    {
          if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            float temp= other.gameObject.GetComponent<Player1>().Damage;
            Debug.Log(temp);
            enemyHealth -=temp;
        }
    }
}
