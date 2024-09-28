using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex!=5)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            SceneManager.LoadScene(0); 
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void ReloadScene() 
    {
        int currentIndexPassedFrom = FindObjectOfType<LoseCollider>().WhatScene();
        Debug.Log(currentIndexPassedFrom);
        SceneManager.LoadScene(currentIndexPassedFrom);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
