using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the scene that represents your game.
        // Replace "GameScene" with the name of your game scene.
        SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        // Exit the game.
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
