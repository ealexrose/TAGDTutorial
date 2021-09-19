using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int coinsToCompleteLevel;

    private TextMeshProUGUI scoreDisplay;
    private int collectedCoins;
    private float worldTimeScale;
    private float slowTimeScale;
    // Start is called before the first frame update, we will use the singleton programming pattern here
    void Awake()
    {
        throw new NotImplementedException();

    }

    //Update runs once per frame, we will check for Global effects here
    private void Update()
    {
        throw new NotImplementedException();
    }

    #region coins
    //Code we want to run whehn you collect a coin
    public void CollectCoin()
    {
        throw new NotImplementedException();
    }

    //Used by coins to increase the amount of coins required to complete the level
    public void IncreaseRequiredCoins()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region level Info
    
    //When our player reaches a death state, call this. We'll be restarting the level here
    public void LoseLevel()
    {
        throw new NotImplementedException();
    }

    //Change the score to reflect the current collected coins
    private void SetScoreDisplay()
    {
        throw new NotImplementedException();
    }

    #endregion


    //Since our time scle variable is protected, we want to provide a way to get access to it that we can control
    public float GetTimeScale() 
    {
        throw new NotImplementedException();
    }



}
