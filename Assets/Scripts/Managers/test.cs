using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float DamageTaken;
    bool IsDead = false;
    public GameObject Coins;
    int coinSpawn = 0;


    void Update()
    {
          if(enemyHealth <= 0)
        {
            IsDead = true;
            Destroy(gameObject);
        }

        if(IsDead == true)
        {
            coinSpawn = Random.Range(1, 6);
                Instantiate(Coins, transform.position, Quaternion.identity);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            float temp= other.gameObject.GetComponent<Player1>().Damage;

            enemyHealth -=temp;
        }
    }
}
