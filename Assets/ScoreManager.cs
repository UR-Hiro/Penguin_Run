using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    private int score;
    void Start()
    {
        GameEvent.current.OnScoreCollided += IncreaseScore;
    }

    private void IncreaseScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
}
