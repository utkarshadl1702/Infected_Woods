using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    DeathHandler deathHandler;

    private void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        deathHandler.BringBackReticle();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
