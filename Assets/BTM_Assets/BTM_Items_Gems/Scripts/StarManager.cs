using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;

    [Header("UI Reference")]
    public GameObject scoreText; 
    
    [Header("Settings")]
    private int starsCollected = 0;
    public int totalStars = 10;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    // This is the ONLY 'AddStar' function you should have
    public void AddStar()
    {
        starsCollected++;
        UpdateUI();

        if (starsCollected >= totalStars)
        {
            Debug.Log("Goal reached: All stars collected!");
        }
    }

    void UpdateUI()
    {
        if (scoreText == null) return;

        string textToDisplay = "Stars: " + starsCollected + " / " + totalStars;
        
        // Supports both TextMeshPro and Legacy Text
        if (scoreText.GetComponent<TextMeshProUGUI>() != null)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = textToDisplay;
        }
        else if (scoreText.GetComponent<UnityEngine.UI.Text>() != null)
        {
            scoreText.GetComponent<UnityEngine.UI.Text>().text = textToDisplay;
        }
    }
}