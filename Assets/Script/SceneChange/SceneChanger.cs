using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneToLoad;
    public Vector2 newPlayerPosition;
    private Transform player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            player.position = newPlayerPosition;
            SceneManager.LoadScene(SceneToLoad);
        }
    }
   
}
