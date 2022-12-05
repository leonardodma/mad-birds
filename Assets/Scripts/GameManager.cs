using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject bird;

    private GameObject[] enemys;

    private GameObject[] boxes;


    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird");
        // set level to 1
        PlayerPrefs.SetInt("levelReached", 1);
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    void CheckWin()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length == 0)
        {
            Debug.Log("You Win!");
            // get current level 
            int level = SceneManager.GetActiveScene().buildIndex - 1;
            PlayerPrefs.SetInt("levelReached", level + 1);
            // load level menu
            SceneManager.LoadScene("LevelMenu");
        }

        // Check if bird is out of bounds, not moving, and there are still enemys
        if (
            bird.GetComponent<Bird>().isReleased &&
            enemys.Length > 0 &&
            (
            bird.GetComponent<Renderer>().isVisible == false ||
            bird.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1
            )
        )
        {
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
