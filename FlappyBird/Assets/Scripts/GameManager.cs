using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;

    private void Awake()
    {
        Application.targetFrameRate= 60;
        Pause();
    }
    public void Play()
    {
        score= 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(true);

        Time.timeScale= 1f;
        player.enabled= true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled= false;
    }
    public void GameOver()
    {
        getReady.SetActive(false);
        gameOver.SetActive(true);
        playButton.SetActive(true);

        score = 0;
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        getReady.SetActive(false);
        scoreText.text = score.ToString();
    }
}
