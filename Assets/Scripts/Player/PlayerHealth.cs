using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHP = 3;
    public float invincibleSeconds = 0.75f;

    public int CurrentHP { get; private set; }

    private bool invincible;

    void Awake()
    {
        CurrentHP = maxHP;
        Debug.Log($"HP: {CurrentHP}/{maxHP}");
    }

    public void TakeDamage(int amount = 1)
    {
        if (invincible) return;
        if (CurrentHP <= 0) return;

        CurrentHP -= amount;
        if (CurrentHP < 0) CurrentHP = 0;

        Debug.Log($"HP: {CurrentHP}/{maxHP}");

        if (CurrentHP <= 0)
        {
            LoseLevel();
            return;
        }

        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleSeconds);
        invincible = false;
    }

    private void LoseLevel()
    {
        Debug.Log("You lost the level! Restarting...");

        // Make sure your scene is added in File > Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}