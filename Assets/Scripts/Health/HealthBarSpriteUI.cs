using UnityEngine;
using UnityEngine.UI;

public class HealthBarSpriteUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image barImage;

    // 0..3 HP sprites
    public Sprite hp0;
    public Sprite hp1;
    public Sprite hp2;
    public Sprite hp3;

    void Awake()
    {
        if (barImage == null) barImage = GetComponent<Image>();
    }

    void Update()
    {
        if (playerHealth == null || barImage == null) return;

        switch (Mathf.Clamp(playerHealth.CurrentHP, 0, 3))
        {
            case 3: barImage.sprite = hp3; break;
            case 2: barImage.sprite = hp2; break;
            case 1: barImage.sprite = hp1; break;
            default: barImage.sprite = hp0; break;
        }
    }
}