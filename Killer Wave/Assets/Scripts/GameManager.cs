using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static int currentScene = 0;
    public static int gameLevelScene = 3;
    bool died = false;
    public bool Died
    {
        get { return died; }
        set { died = value; }
    }

    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        CheckGameManagerIsInTheScene();
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        LightAndCameraSetup(currentScene);
    }

    void CheckGameManagerIsInTheScene()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void LightAndCameraSetup(int sceneNumber)
    {
        switch (sceneNumber)
        {
            // testLevel, level1, level2, level3
            case 3: case 4: case 5: case 6:
                {
                    LightSetup();
                    CameraSetup();
                    break;
                }
        }
    }

    void CameraSetup()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        // Camera Transoform
        gameCamera.transform.position = new Vector3(0, 0, -300);
        gameCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        // Camera Properties
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        gameCamera.GetComponent<Camera>().backgroundColor = Color.black;
    }

    void LightSetup()
    {
        GameObject dirLight = GameObject.Find("Directional Light");
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Light>().color = new Color32(152, 204, 255, 255);
    }
}
