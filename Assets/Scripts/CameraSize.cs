using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private Camera cam;

    public static float halfScreenWidth{get; private set;}
    public static float halfScreenHeight{get; private set;}


    private void Awake(){
        cam = Camera.main;

        halfScreenHeight = cam.orthographicSize;

        halfScreenWidth = halfScreenHeight * cam.aspect;
    }
}
