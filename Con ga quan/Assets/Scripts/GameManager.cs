using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    private PlayerStatsUI playerStatsUI;

    [Header("Game State Management")]
    public GameState currentGameState;
    public enum GameState
    {
        Menu,
        Shop,
        EndGame
    }

    [Header("Player State and Stat Management")]
    int stimulusCheck = 20;

    [Header("High Score Management")]
    [SerializeField] public int highScore;
    public int score = 0;

    [Header("Menu Management")]
    public TextMeshProUGUI highScoreText;

    void OnEnable()
    {

        PlayerStatsInit();
        HighScoreInit();

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            highScoreText.text += highScore;
        }

        playerStatsUI = GetComponent<PlayerStatsUI>();
    }

    #region GameState Management
    //do things when game state changes
    void GameStateCheck()
    {
        //do things according to what game state it is
        switch (currentGameState)
        {
            case GameState.Menu:

                break;
            case GameState.Shop:

                break;
            case GameState.EndGame:

                break;
            default:

                break;
        }
    }

    //change the game state
    void SetGameState(GameState gameState)
    {
        currentGameState = gameState;
        GameStateCheck();
    }
    #endregion

    #region CheckOut Management

    public void Summary()
    {

        //removes health from the player
        //auto depletion
        //stimulus check
        WeeklyDepletion();
        

        if (PlayerIsAlive())
        {
            score++;
            Debug.Log("The player survived this week");
            //reaload or show UI
        }
        else
        {
            HighScoreCheck();
            Debug.Log("The player died this week");
            //end the game, show quit button
        }
    }

    #endregion

    #region PlayerStates
    //inits the players stats script 
    void PlayerStatsInit()
    {
        //set health to max health
        //PlayerStats.Health = PlayerStats.MaxHealth;
        Debug.Log(PlayerStats.Health);
    }

    //check the player stat
    //should be called when the players health is updated
    bool PlayerIsAlive()
    {
        if (PlayerStats.Health <= 0 || PlayerStats.Money <= 0)
        {
            currentGameState = GameState.EndGame;
            return false;
        }
        return true;
    }

    void WeeklyDepletion()
    {
        PlayerStats.Health -= 10;
        PlayerStats.Money -= Random.Range(8, 12);
        PlayerStats.Money += stimulusCheck;
        playerStatsUI.UpdatePlayerStatsUI();
    }
    #endregion

    #region HighScore
    void HighScoreInit()
    {
        if (highScore == 0)
        {
            highScore = PlayerPrefs.GetInt("High Score");
        }
    }

    void SetCurrentScoreAsHighScore()
    {
        PlayerPrefs.SetInt("High Score", score);
        highScore = PlayerPrefs.GetInt("High Score");

    }
    int GetCurrentHighScore()
    {
        return PlayerPrefs.GetInt("High Score");
    }

    private void ResetHighScore()
    {
        PlayerPrefs.SetInt("High Score", 0);
        highScore = PlayerPrefs.GetInt("High Score");
    }

    public void HighScoreCheck()
    {
        if(score > highScore)
        {
            SetCurrentScoreAsHighScore();
        }
    }
    #endregion


    #region Scene Management

    

    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public GameObject resolutionScreen;
    public Timer timer;

    private void Update()
    {

        if (timer.startTimer <= 0)
        {
            if (PlayerIsAlive() == true)
            {
                //resolutionScreen.SetActive(false);
                LoadScene(2);
                //resolutionScreen.SetActive(false);
            }
            else resolutionScreen.SetActive(true);
        }   

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadScene(2);
        }
    }
    #endregion

    public void Quit()
    {
        Application.Quit();
    }

}
