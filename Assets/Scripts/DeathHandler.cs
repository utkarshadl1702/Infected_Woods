using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas removeIt;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        removeIt.enabled=false;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled=false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BringBackReticle()
    {
        removeIt.enabled=true;
    }
}
