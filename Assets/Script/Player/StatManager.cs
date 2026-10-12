using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    [Header("HeartImage")]
    public Sprite EmtyHeart;
    public Sprite fullHeart;
    public Sprite Heart1;
    public Sprite Heart2;
    public Sprite Heart3;
    public Sprite Heart4;

    [Header("HeartUI")]
    public Image[] hearts;
    public Animator healthAnim;

    [Header("HealthCounter")]
    public float result;

    public static StatManager Instance;
    public StatsUI statsUI;
    public TMP_Text healthText;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int moveSpeed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    public PlayerHealth playerHealth;
    private void Start()
    {
        UpdateMaxHealth(0);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;

        result = (float) currentHealth /maxHealth;
        healthText.text = + currentHealth + "/" + maxHealth;

        healthAnim.Play("HealthUI");

        if (StatManager.Instance.currentHealth <= 0)
        {
            hearts[0].sprite = EmtyHeart;
            playerHealth.Die();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else if (result <= 0.21)
        {
            hearts[0].sprite = Heart1;
        }
        else if (result <= 0.41 && result > 0.2)
        {
            hearts[0].sprite = Heart2;
        }
        else if (result <= 0.61 && result > 0.4)
        {
            hearts[0].sprite = Heart3;
        }
        else if (result < 1 && result > 0.6)
        {
            hearts[0].sprite = Heart4;
        }
        else if (result == 1)
        {

            hearts[0].sprite = fullHeart;
        }
       
    }
    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
             // To refresh UI
        }
        healthText.text = +currentHealth + "/" + maxHealth;
        UpdateMaxHealth(0);
    }
    public void UpdateMoveSpeed(int amount)
    {
        moveSpeed += amount;
        statsUI.UpdateAllStats();
    }
    public void UpdateDamage(int amount)
    {
        damage += amount;
        statsUI.UpdateAllStats();
    }
}
