using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public static GameOverController instance;
    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private Text gameOverText;
    private void Awake() {
        if(instance ==  null){
            instance = this;
        }
    }
    public void ToMainMenu(){
        SceneManager.LoadScene("MainMenuScene");
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver(string gameoverInfo, Image image){
        gameOverText.text = gameoverInfo;
        gameOverCanvas.enabled = true;
        image.enabled = true;
    }
    
}
