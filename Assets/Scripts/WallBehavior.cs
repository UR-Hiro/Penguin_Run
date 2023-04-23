using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    [SerializeField] private GameObject wallInstance;
    [SerializeField] private Transform instancePosition;

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player")){
            Instantiate(wallInstance, instancePosition.position, Quaternion.identity);
        }
    }
}
