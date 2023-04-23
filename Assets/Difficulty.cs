using UnityEngine;

public static class Difficulty
{
    private static float MaxDifficultyTime = 30f;
    public static float ReturnDifficultyPercentage(){
        float difficultyPercent = Time.realtimeSinceStartup/MaxDifficultyTime;
        return Mathf.Clamp01(difficultyPercent);
    }
}
