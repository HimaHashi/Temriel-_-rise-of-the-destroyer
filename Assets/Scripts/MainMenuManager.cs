using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Variables
    [Header("User Interface")]
    public bool isCursorHidden = true;
    private SceneLoader sceneLoader;
    [Header("Scenes indexes")]
    public int settingsScene = 1;
    public int creditsScene = 2;
    public int gameScene = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<SceneLoader>();
        sceneLoader = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCursorHidden)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Functions
    public void PlayGame()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(gameScene);
    }

    public void SettingsGame()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(settingsScene);
    }
    
    public void CreditsGame()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(creditsScene);
    }

    public void QuitGame()
    {
        // Closing application
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
