using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject fim;
    

    void Awake(){
        instance = this;
    }
    void Start()
    {
        fim.SetActive(false);
    }

    void Update()
    {
        
    }
    public void GameOver(){
        fim.SetActive(true);


    }
    
}
