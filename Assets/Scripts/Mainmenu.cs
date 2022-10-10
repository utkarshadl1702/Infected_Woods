using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
             
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnClick()
    {
       SceneManager.LoadScene("MainScene");
    }
    public void _QuitGame()
    {
        Application.Quit();
    }
}
