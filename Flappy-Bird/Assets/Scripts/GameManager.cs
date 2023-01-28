using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause(); //pauses game on start
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f; //resumes time
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() //makes sure all element is in place at the start of the game
    {
        Time.timeScale = 0f; //pauses time and make the update function in all files not work
        player.enabled = false; //diable players from moving on input
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);//shows the game over image and play button when game is over

        Pause(); //pauses the game when the game is over
    }

    public void IncreaseScore()
    {
        score++;

        scoreText.text = score.ToString(); //converts int to string
    }

}
