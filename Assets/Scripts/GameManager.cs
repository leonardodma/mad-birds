using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject bird;

    private GameObject[] enemys;

    private GameObject[] boxes;

    private bool boxMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird");
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    void CheckWin()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        boxes = GameObject.FindGameObjectsWithTag("Box");

        if (enemys.Length == 0)
        {
            Debug.Log("You Win!");
        }

        // Check if there are elements with tag box moving
        foreach (GameObject box in boxes)
        {
            if (box.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                boxMoving = true;
                break;
            }

            boxMoving = false;
        }

        Debug.Log (boxMoving);

        // Check if bird is out of bounds, not moving, and there are still enemys
        if (
            bird.GetComponent<Bird>().isReleased &&
            enemys.Length > 0 &&
            (
            bird.GetComponent<Renderer>().isVisible == false ||
            bird.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1
            ) &&
            !boxMoving
        )
        {
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
