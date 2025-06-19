using UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private DisplayScore scoreDisplay;
    private int totalScore = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddPoints(int points)
    {
        totalScore += points;
        scoreDisplay.SetPoints(totalScore);
    }

    public int GetScore()
    {
        return totalScore;
    }
}
