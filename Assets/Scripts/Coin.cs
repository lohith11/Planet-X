using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{   
    public int coinCount = 0;
    public Text coinText;
    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log("coins :" +coinCount);
       
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  Debug.Log("coin collected");
            coinCount++;
            coinText.text = coinCount.ToString();
            //Destroy(gameObject);
        }   
    }
}
