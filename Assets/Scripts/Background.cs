using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 25f;
    private Vector3 startPosition;
    private float halfWidth = 112.8f / 2.0f;

    void Start(){
        startPosition = transform.position;
    }
    void Update(){
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        if (transform.position.x < startPosition.x - halfWidth){
            transform.position += new Vector3(halfWidth, 0, 0);
        }
    }
}
