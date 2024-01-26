using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text winText;

    void Start()
    {
        winText.enabled = false;
    }

    void Update()
    {
        if (IsGameOver())
        {
            winText.enabled = true;
            winText.text = "Œ“ »—!";
            if (Input.GetMouseButtonDown(0))
            {
                RestartGame();
            }
        }
        if (AllBricksDestroyed())
        {
            winText.enabled = true;
            winText.text = "’Œ–Œÿ!";
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            if (Input.GetMouseButtonDown(0))
            {
                RestartGame();
            }
        }
    }

    bool AllBricksDestroyed()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        return bricks.Length == 1;
    }

    bool IsGameOver()
    {
        return GameObject.FindGameObjectWithTag("Ball") == null;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
