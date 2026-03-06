using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Loads the next scene in the build queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
{
    // This message shows in the Console to prove it works
    Debug.Log("The player has quit the game!"); 
    
    // This closes the actual application
    Application.Quit();
}

}