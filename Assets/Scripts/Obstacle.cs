using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float moveSpeed = 25f;
    private float xBoundary = -20f;

    void Update(){
        if (transform.position.x < xBoundary){
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate(){
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
}
