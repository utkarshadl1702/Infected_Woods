using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBattery : MonoBehaviour
{

    LightSwitch _switch;
    float startIntensity;
    // Start is called before the first frame update
    void Start()
    {
        _switch = FindObjectOfType<LightSwitch>();
        startIntensity = _switch.lightIntensity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _switch.lightIntensity = startIntensity;
            Destroy(gameObject);/* s */
        }
    }
}
