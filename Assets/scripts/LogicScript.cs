using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    // public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject titleScreen; // Drag your Title Canvas or Panel here
    public GameObject pipeSpawner; // Drag your Pipe Spawner object here

    void Start() 
    {
        // 1. Freeze the game immediately so the fish doesn't fall
        Time.timeScale = 0;
        
        // 2. Ensure the title screen is visible and game over is hidden
        titleScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        
        // 3. Keep the pipe spawner off so pipes don't pile up behind the menu
        if (pipeSpawner != null) pipeSpawner.SetActive(false);

        // UpdateHighScoreUI();
    }

    public void startGame()
    {
        // 1. Hide the menu
        titleScreen.SetActive(false);
        
        // 2. Unfreeze time so physics starts working
        Time.timeScale = 1;

        // 3. Turn on the pipe spawner
        if (pipeSpawner != null) pipeSpawner.SetActive(true);
    }

   
 public AudioSource dingSFX; // New variable for the sound

    public void addScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();

        // PLAY THE SOUND HERE
        if (dingSFX != null) 
        {
            dingSFX.Play();
        }
        
        // ... rest of your high score logic ...
    }

    // void UpdateHighScoreUI()
    // {
    //     highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    // }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; 
    }
}