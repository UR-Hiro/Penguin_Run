using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverImg;
    // Start is called before the first frame update
    void Start()
    {
        gameOverImg.SetActive(false);
        GameEvent.current.OnGameOver += GameOver;
    }

    private void GameOver()
    {
        gameOverImg.SetActive(true);
    }

    private void Update(){
        if(!gameOverImg.activeInHierarchy) return;
        if(!Input.GetMouseButton(0))return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // if(gameOverImg.activeInHierarchy && Input.GetMouseButton(0)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
