using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    float gameTimer = 0;
    float[] endLeveltimer = { 30, 30, 45 };
    int currentSceneNumber = 0;
    bool gameEnding = false;

    Scenes scenes;
    public enum Scenes
    {
        bootUp,
        title,
        shop,
        Level1,
        Level2,
        Level3,
        gameOver
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (currentSceneNumber != SceneManager.GetActiveScene().buildIndex)
        {
            currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            GetScene();
        }
        GameTimer();
    }

    public void ResetScene()
    {
        gameTimer = 0;
        SceneManager.LoadScene(GameManager.currentScene);
    }

    public void GameOver()
    {
        Debug.Log("ENDSCORE: " + GameManager.Instance.GetComponent<ScoreManager>().PlayersScore);
        SceneManager.LoadScene("gameOver");
    }

    public void BeginGame(int gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }
    
    void GetScene()
    {
        scenes = (Scenes)currentSceneNumber;
    }

    void NextLevel()
    {
        gameEnding = false;
        gameTimer = 0;
        SceneManager.LoadScene(GameManager.currentScene + 1);
    }
    
    void GameTimer()
    {
        switch(scenes)
        {
            case Scenes.Level1: case Scenes.Level2: case Scenes.Level3:
                {
                    if (gameTimer < endLeveltimer[currentSceneNumber - 3])
                    {
                        // if level has not been completed
                        gameTimer += Time.deltaTime;
                    }
                    else
                    {
                        // if level is cimpleted
                        if (!gameEnding)
                        {
                            gameEnding = true;
                            if (SceneManager.GetActiveScene().name != "level3")
                            {
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTransition>().LevelEnds = true;
                            }
                            else
                            {
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTransition>().GameCompleted = true;
                            }
                            Invoke("NextLevel", 4);
                        }
                    }
                    break;
                }
        }
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        GetComponent<GameManager>().SetLivesDisplay(GameManager.playerLives);
    }
}
