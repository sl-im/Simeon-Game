using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // create a singleton for this target
    public static GameManager Instance {get; private set;}
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject pickupParent; 
    public int totalPickups = 0;
    private PlayerControls player;
    public GameObject victoryText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Cannot have more that one instance of [GameManager] in the scene! Deleted extra copy");
            Destroy(this.gameObject);
        }
           
        
    }

   
   private void Start()
    {
        score = 0;
        UpdateScoreText();

      victoryText.SetActive(false); // disabled the victory text when the game starts

        totalPickups = pickupParent.transform.childCount;//count how many pickups are in the level
        //count how many pick ups are in the game
    }
    public void UpdateScore(int amount)
    {
        score = score + amount;
        UpdateScoreText();

        if(totalPickups <= 0)
        {
            WinGame();
        }
    }
    public void UpdateScoreText()
        {
            //string  //int
            scoreText.text = "Score " + score.ToString();
        }
        public void WinGame()
        {
            victoryText.SetActive(true);
            GameOver();
        }
    public void GameOver()
    {
        Invoke("LoadCurrentLevel",2f);
    }
    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoseGame()
    {
        if(player.health <= 0)
        {
            GameOver();
        }
    }
}
