using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float speed;
    public float offset;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);   

        if(transform.position.x < -CameraSize.halfScreenWidth - offset) Destroy(this.gameObject);
    }
}
