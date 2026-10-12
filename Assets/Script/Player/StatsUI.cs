using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] statsSlot;
    public CanvasGroup statsCanvas;

    private bool statsOpen = false;
    private void Start()
    {
      
        UpdateAllStats();
    }
    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
            if (statsOpen)
            {
                Time.timeScale = 1;
                UpdateAllStats();
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                statsOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                UpdateAllStats();
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                statsOpen = true;
            }
    }
    public void UpdateDamage()
    {
        statsSlot[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatManager.Instance.damage;
    }
    public void UpdateMoveSpeed()
    {
        statsSlot[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatManager.Instance.moveSpeed;
    }
    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateMoveSpeed();
    }
}
