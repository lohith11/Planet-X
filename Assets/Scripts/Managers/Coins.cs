using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            print("Player collected " + coinValue + " coins!");
            ScoreManager.ScoreInstance.Addcoins(coinValue);

            FindObjectOfType<AudioManager>().PlaySound("CoinPickup");
            Destroy(gameObject);
        }   
    }
}
