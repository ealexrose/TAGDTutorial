using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int coinsToCompleteLevel = 0;

    private TextMeshProUGUI scoreDisplay;
    private int collectedCoins = 0;

    private float worldTimeScale = 1f;
    private float slowTimeScale = 0.3f;
    // Start is called before the first frame update, we will use the singleton programming pattern here
    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    //Update runs once per frame, we will check for Global effects here
    private void Update()
    {
        if (Input.GetButton("Slow"))
        {
            worldTimeScale = slowTimeScale;
        }
        else 
        {
            worldTimeScale = 1f;
        }

        if (Input.GetButtonDown("Cancel")) 
        {
            Application.Quit();
        }
    }

    #region coins

    //Code we want to run whehn you collect a coin
    public void CollectCoin()
    {
        collectedCoins++;
        SetScoreDisplay();
        if (collectedCoins == coinsToCompleteLevel)
        {
            Debug.Log("You won the level!");
            SceneManager.LoadScene("WinScreen");
        }
    }

    //Used by coins to increase the amount of coins required to complete the level
    public void IncreaseRequiredCoins()
    {
        coinsToCompleteLevel++;
        SetScoreDisplay();
    }
    #endregion

    #region level Info
    //When our player reaches a death state, call this. We'll be restarting the level here
    public void LoseLevel()
    {
        coinsToCompleteLevel = 0;
        collectedCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Change the score to reflect the current collected coins
    private void SetScoreDisplay()
    {
        if (scoreDisplay == null)
        {
            scoreDisplay = FindObjectOfType<TextMeshProUGUI>();
        }
        scoreDisplay.text = collectedCoins.ToString("D2") + "/" + coinsToCompleteLevel.ToString("D2");
    }

    #endregion

    //Since our time scle variable is protected, we want to provide a way to get access to it that we can control
    public float GetTimeScale() 
    {
        return worldTimeScale;
    }



}
