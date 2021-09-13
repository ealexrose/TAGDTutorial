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
    // Start is called before the first frame update
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

    public void IncreaseRequiredCoins()
    {
        coinsToCompleteLevel++;
        SetScoreDisplay();
    }
    #endregion

    #region level Info
    public void LoseLevel()
    {
        coinsToCompleteLevel = 0;
        collectedCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetScoreDisplay()
    {
        if (scoreDisplay == null)
        {
            scoreDisplay = FindObjectOfType<TextMeshProUGUI>();
        }
        scoreDisplay.text = collectedCoins.ToString("D2") + "/" + coinsToCompleteLevel.ToString("D2");
    }

    #endregion


    public float GetTimeScale() 
    {
        return worldTimeScale;
    }



}
