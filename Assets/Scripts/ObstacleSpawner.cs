using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstacleBehavior[] obstacles;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Vector2 waitTime;
    [SerializeField] private Vector2 obstacleSpeed;

    private Vector2 spawnPos;
    void Start()
    {
        spawnPos = new Vector2(CameraSize.halfScreenWidth + offset.x, offset.y);    
        StartCoroutine(ObstacleSpawn());
    }

    private IEnumerator ObstacleSpawn(){
        yield return new WaitForSeconds(Random.Range(waitTime.x,waitTime.y));
        ObstacleBehavior obstacleInstance = Instantiate(obstacles[Random.Range(0,obstacles.Length)],spawnPos, Quaternion.identity); 
        obstacleInstance.speed = Mathf.Lerp(obstacleSpeed.x, obstacleSpeed.y, Difficulty.ReturnDifficultyPercentage());
        obstacleInstance.offset = offset.x;
        StartCoroutine(ObstacleSpawn());

    }
}
