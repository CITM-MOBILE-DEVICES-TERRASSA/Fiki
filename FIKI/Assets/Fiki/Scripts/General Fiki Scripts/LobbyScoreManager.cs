using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UpdateLobbyScore : MonoBehaviour
{
    // Singleton Instance
    public static UpdateLobbyScore Instance { get; private set; }

    [Header("UI Elements")]
    public TextMeshProUGUI FikiText;          
    public TextMeshProUGUI JumpingJackText;  
    public TextMeshProUGUI TotalScoreText;

    [HideInInspector]
    public int Game1Score { get; private set; } //(Fiki)
    [HideInInspector]
    public int Game2Score { get; private set; } //(Jumping Jack)

    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//si quisieramos q algo persista entre escenas modificar o eliminar esto
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AssignReferences();
        UpdateScoreTotal();
    }

    private void Update()
    {
        ShowScoreTexts();
    }
        
    public void UpdateGame1Score(int newScore)
    {
        Game1Score = newScore;
        Debug.Log("Puntuaci�n de FIKI actualizada: " + Game1Score);
        UpdateScoreTotal();
    }
        
    public void UpdateGame2Score(int newScore)
    {
        Game2Score = newScore;
        Debug.Log("Puntuaci�n de Jumping Jack actualizada: " + Game2Score);
        UpdateScoreTotal();
    }
        
    private void ShowScoreTexts()
    {
        if (FikiText != null)
        {
            FikiText.text = "Fiki: " + Game1Score;
        }
        else
        {
            Debug.LogError("FikiText no est� asignado en el inspector.");
        }

        if (JumpingJackText != null)
        {
            JumpingJackText.text = "JumpingJack: " + Game2Score;
        }
        else
        {
            Debug.LogError("JumpingJackText no est� asignado en el inspector.");
        }

        if (TotalScoreText != null)
        {
            TotalScoreText.text = "Total Score: " + (Game1Score + Game2Score);
        }
        else
        {
            Debug.LogError("TotalScoreText no est� asignado en el inspector.");
        }
    }
        
    private void UpdateScoreTotal()
    {
        int totalScore = Game1Score + Game2Score;

        if (TotalScoreText != null)
        {
            TotalScoreText.text = "Total Score: " + totalScore;
        }

        Debug.Log("Puntuaci�n total actualizada: " + totalScore);
    }

    private void AssignReferences()
    {
        if (FikiText == null)
            FikiText = GameObject.Find("FikiText").GetComponent<TextMeshProUGUI>();

        if (JumpingJackText == null)
            JumpingJackText = GameObject.Find("JumpingJackText").GetComponent<TextMeshProUGUI>();

        if (TotalScoreText == null)
            TotalScoreText = GameObject.Find("TotalScoreText").GetComponent<TextMeshProUGUI>();
    }
}

