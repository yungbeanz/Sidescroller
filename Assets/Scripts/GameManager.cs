using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Background background;
    [SerializeField] private SpawnManager spawnManager;

    public void EndGame(){
        background.enabled = false;
        spawnManager.enabled = false;
        StartCoroutine(Reset());
    }
    IEnumerator Reset(){
        yield return new WaitForSeconds(3f);
        spawnManager.DestroyObstacles();
        background.enabled = true;
        spawnManager.enabled = true;
        playerController.Reset();
    }
}
