using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Light _light;
    public float lightIntensity = 30;
    bool isOn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
        }

        if (isOn)
        {
            _light.intensity = lightIntensity;

            if (lightIntensity > 0)
            {
                lightIntensity -= 1*Time.deltaTime;

            }
            else
            {
                lightIntensity = 0;
            }
        }
        else
        {
            _light.intensity = 0;
        }
    }
}
