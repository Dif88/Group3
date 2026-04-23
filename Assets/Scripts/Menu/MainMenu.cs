using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Loads the next scene in the build queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Here is your brand new method for the Explore button!
    public void ExploreGame()
    {
        // Make sure the name in quotes exactly matches how you spelled your scene file
        SceneManager.LoadScene("Exploration"); 
    }

    public void QuitGame()
    {
        // This message shows in the Console to prove it works
        Debug.Log("The player has quit the game!"); 
        
        // This closes the actual application
        Application.Quit();
    }
}