using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
=======
    public float enemyHealth = 100f;
    public float DamageTaken;

    
>>>>>>> Stashed changes
    void Start()
    {
        
    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
        
=======

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
            enemyHealth -= other.gameObject.GetComponent<Player1>().Damage;
        }
>>>>>>> Stashed changes
    }
}
