using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

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
    }

    public void resetScore()
    {
        playerScore = 0;
    }
}
