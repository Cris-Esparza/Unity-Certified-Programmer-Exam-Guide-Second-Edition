using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static int playerScore;
    public int PlayersScore
    {
        get
        {
            return playerScore;
        }
    }

    public void SetScore(int incomingScore)
    {
        playerScore += incomingScore;
        UpdateScore();
    }

    public void resetScore()
    {
        playerScore = 00000000;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (GameObject.Find("score"))
        {
            GameObject.Find("score").GetComponent<Text>().text = playerScore.ToString();
        }
    }
}
