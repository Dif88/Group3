using UnityEngine;
using TMPro; // Required for TextMeshPro

public class StarManager : MonoBehaviour
{
    public static StarManager instance; // Allows stars to find this easily

    public TextMeshProUGUI scoreText;
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

    public void AddStar()
    {
        starsCollected++;
        UpdateUI();

        if (starsCollected >= totalStars)
        {
            Debug.Log("All stars collected! You win!");
            // You can trigger a Win Screen here later
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Stars: " + starsCollected + " / " + totalStars;
    }
}