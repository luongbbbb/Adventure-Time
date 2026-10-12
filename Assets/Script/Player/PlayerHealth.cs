using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
   
    public Sprite EmtyHeart;
    public Sprite fullHeart;
    public Sprite Heart1;
    public Sprite Heart2;
    public Sprite Heart3;
    public Sprite Heart4;
    public Image[] hearts;
    public Animator healthAnim;
    public AudioSource gethit;

    public TMP_Text healthText;
   
    //public float result;

    //private void Start()
    //{
    //    //    healthText.text = +StatManager.Instance.currentHealth +
    //    //        "/" + StatManager.Instance.maxHealth;
    //    ChangeHealth(0);
    //}

    public void ChangeHealth(int amount)
    {
        StatManager.Instance.currentHealth += amount;

        StatManager.Instance.result = (float)StatManager.Instance.currentHealth /
            StatManager.Instance.maxHealth;

        healthText.text = StatManager.Instance.currentHealth +
            "/" + StatManager.Instance.maxHealth;

        gethit.Play();
        healthAnim.Play("HealthUI");

        if (StatManager.Instance.currentHealth <= 0)
        {
            hearts[0].sprite = EmtyHeart;
            Die();
        }
        else if (StatManager.Instance.result <= 0.21)
        {
            hearts[0].sprite = Heart1;
        }
        else if (StatManager.Instance.result <= 0.41 
            && StatManager.Instance.result > 0.2)
        {
            hearts[0].sprite = Heart2;
        }
        else if (StatManager.Instance.result <= 0.61 
            && StatManager.Instance.result > 0.4)
        {
            hearts[0].sprite = Heart3;
        }
        else if (StatManager.Instance.result < 1 
            && StatManager.Instance.result > 0.6)
        {
            hearts[0].sprite = Heart4;
        }
        else if (StatManager.Instance.result == 1)
        {

            hearts[0].sprite = fullHeart;
        }

    }
    public void Die()
    {

        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
