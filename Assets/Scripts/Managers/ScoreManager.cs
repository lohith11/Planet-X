using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager ScoreInstance;
    public TextMeshProUGUI CoinText;
    int coinCount;
    
    void Start()
    {
        ScoreInstance = this;
    }

    public void Addcoins(int coins)
    {
        print("Coin added");
        coinCount += coins;
       CoinText.text = coinCount.ToString();
    }

}
