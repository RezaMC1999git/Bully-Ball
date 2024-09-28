using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    int currentScene;
    private void OnTriggerEnter2D(Collider2D collision) {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(currentScene); 
    }
    public int WhatScene() 
    {
        return currentScene;
    }
}
