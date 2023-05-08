using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform slingshotSpawn;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void SlingshotSelected(GameObject slingshot)
    {
        Instantiate(slingshot, slingshotSpawn.position, Quaternion.identity);

    }
    public void BirdSelected(GameObject bird)
    {
        Instantiate(bird, spawnPoint.position, Quaternion.identity);
    }
}
