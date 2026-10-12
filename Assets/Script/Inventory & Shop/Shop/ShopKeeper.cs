using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public static ShopKeeper currentShopKeeper;

    public Animator anim;
    public CanvasGroup shopCanvasGroup;
    public ShopManager shopManager;
    [SerializeField] private List<ShopItem> shopItems;
    [SerializeField] private List<ShopItem> shopWeapons;
    [SerializeField] private List<ShopItem> shopArmour;
    public static event Action<ShopManager, bool> OnShopStateChanged;
    private bool playerInRange;
    private bool isShopOpen;
    void Update()
    {
        if(playerInRange )
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (!isShopOpen)
                {
                    Time.timeScale = 0f;
                    currentShopKeeper = this;
                    isShopOpen = true;
                    OnShopStateChanged?.Invoke(shopManager, true);

                    shopCanvasGroup.alpha = 1;
                    shopCanvasGroup.interactable = true;
                    shopCanvasGroup.blocksRaycasts = true;
                    OpenItemShop();
                }
            }
                else if (Input.GetButtonDown("Cancel"))
                {
                    Time.timeScale = 1f;
                    currentShopKeeper = null;
                    isShopOpen = false;
                    OnShopStateChanged?.Invoke(shopManager, false);
                    shopCanvasGroup.alpha = 0;
                    shopCanvasGroup.interactable = false;
                    shopCanvasGroup.blocksRaycasts = false;
                }
            
        }
    }
    public void OpenItemShop()
    {
        shopManager.PopulateShopItems(shopItems);
    }
    public void OpenWeaponShop()
    {
        shopManager.PopulateShopItems(shopWeapons);
    }
    public void OpenArmourShop()
    {
        shopManager.PopulateShopItems(shopArmour);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = true;
            anim.SetBool("PlayerInRange", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            anim.SetBool("PlayerInRange", false);
        }
    }
}
