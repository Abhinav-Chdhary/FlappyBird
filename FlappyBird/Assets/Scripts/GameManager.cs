using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    public void GameOver()
    {
        Debug.Log("Game over\n");
    }
    public void IncreaseScore()
    {
        score++;
    }
}
