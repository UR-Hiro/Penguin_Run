using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;
    void Awake(){
        current = this;
    }
    //event
    public event Action OnScoreCollided;
    public event Action OnGameOver;

    //method
    public void ScoreCollided() => OnScoreCollided?.Invoke();
    public void GameOver() => OnGameOver?.Invoke();
}
