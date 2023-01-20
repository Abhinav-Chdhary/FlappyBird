using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    //public float rotationDuration = 1f; //adjust the rotation duration
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    //private Quaternion initialRotation; //to store initial rotation

    private void Awake()
    {
        Application.targetFrameRate= 60;
        //initialRotation= transform.rotation;
        Pause();
    }
    private void Update()
    {
        //if(score%3==0 && score>0)
        //{
        //    player.transform.Rotate(Vector3.forward, 360f * Time.deltaTime/rotationDuration);
        //}//barrel roll every 3 points
    }
    public void Play()
    {
        score= 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

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
        gameOver.SetActive(true);
        playButton.SetActive(true);
        //player.transform.rotation= initialRotation; //back to initial
        score = 0;
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
