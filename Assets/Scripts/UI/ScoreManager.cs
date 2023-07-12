using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int currentScore;
    private int highestScore;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)Player.position.z / 2).ToString(); 
    }

    public void EndScore()
    {
        currentScore = int.Parse(scoreText.text);
        Debug.Log(currentScore);
        if(currentScore > highestScore)
        {
            highestScore = currentScore;
        }
    }
}
