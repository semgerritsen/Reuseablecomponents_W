using System;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private DisplayScore scoreDisplay;
    [SerializeField] private DisplayTime timeDisplay;
    [SerializeField] private int targetScore;
    [SerializeField] private float timeLimit = 60;

    [Header("Win/Lose Scenes")]
    [SerializeField] private string winSceneName;
    [SerializeField] private string loseSceneName;
    
    private float timer; 
    private int totalScore = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        timer = timeLimit;
    }

    private void Update()
    {
        CheckWinOrLose();
        Console.WriteLine(totalScore);
    }

    private void CheckWinOrLose()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && totalScore < targetScore)
            LoseGame();
        else if (totalScore >= targetScore)
            WinGame();
        
        timeDisplay.SetTime(timer);
    }

    private void LoseGame()
    {
        SceneManager.LoadScene(loseSceneName);
        Cursor.lockState = CursorLockMode.None;
    }

    private void WinGame()
    {
        SceneManager.LoadScene(winSceneName);
        Cursor.lockState = CursorLockMode.None;
    }

    public void AddPoints(int points)
    {
        totalScore += points;
        scoreDisplay.SetPoints(totalScore);
    }
}
