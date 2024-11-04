using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public int lives = 3;
    public int score;
    public int maxscore;
    public int currentLevel;

    public GameObject pauseCanvas;
    public bool isPaused = false;

    [SerializeField] private TextMeshProUGUI currentLevelText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        currentLevel = 3;
        pauseCanvas.SetActive(false);
        currentLevelText.text = currentLevel.ToString();
    }
    public void PauseisActive()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseisNotActive()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void LevelCompleted()
    {
        SceneManager.LoadScene("RewardScreen");
    }
    public void Save()
    {
        Debug.Log("GAME SAVED");
        PlayerPrefs.SetInt("HighScore", maxscore);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("Lives", lives);
    }
    public void Load()
    {
        Debug.Log("GAME LOAD");
        maxscore = PlayerPrefs.GetInt("HighScore", 0);
        score = PlayerPrefs.GetInt("Score", 0);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        lives = PlayerPrefs.GetInt("Lives", 0);

        Debug.Log("HighScore " + maxscore);
        Debug.Log("Score " + score);
        Debug.Log("Lives " + lives);
        Debug.Log("Level " + currentLevel);
    }
}
