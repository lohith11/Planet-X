using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    

    void Pickup(Collider2D player)
    {
        Debug.Log("Powerup picked up");
        Player1.Instance.health += 200f;
        Destroy(gameObject);
    }
}
