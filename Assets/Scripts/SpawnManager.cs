using UnityEngine;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPt;
    private float startDelay = 2;
    private float repeatRate = 2;
    List<Obstacle> obstacles;

    void Start(){
        obstacles = new List<Obstacle>();
    }

    void OnEnable()
    {
          InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
    void OnDisable(){
        CancelInvoke();
        // disable active obstacles.
        for (int i = 0; i < obstacles.Count; i++){
            if(obstacles[i] != null) {
                obstacles[i].enabled = false;
            }
        }
    }
    private void SpawnObstacle(){
        GameObject obj = Instantiate(obstaclePrefab, spawnPt.position, obstaclePrefab.transform.rotation);  
        Obstacle obstacle = obj.GetComponent<Obstacle>();
        obstacles.Add(obstacle);
    }
    public void DestroyObstacles(){
        for (int i = 0; i < obstacles.Count; i++){
            if (obstacles[i] != null) {
                Destroy(obstacles[i].gameObject);
            }
        }        
    }
}
