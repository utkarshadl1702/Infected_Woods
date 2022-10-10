using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightUI : MonoBehaviour
{

    LightSwitch _switch;
    PlayerHealth playerHealth;
    public Scrollbar scrollbar; 
    public Scrollbar healthScroll; 
     float maxLightIntensity;
    // Start is called before the first frame update
    void Start()
    {
        _switch=FindObjectOfType<LightSwitch>();
        maxLightIntensity=_switch.lightIntensity;

        playerHealth = FindObjectOfType<PlayerHealth>();

        Cursor.visible=true;
    }

    // Update is called once per frame
    void Update()
    {
        scrollbar.value = _switch.lightIntensity/maxLightIntensity;
        healthScroll.value = playerHealth.retHealth()/100;
    }
}
