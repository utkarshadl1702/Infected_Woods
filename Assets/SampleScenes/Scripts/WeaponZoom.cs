using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 3f;
    [SerializeField] Canvas retical;
    [SerializeField] float zoomedInSensitivity = 2f;
    [SerializeField] float zoomedOutSensitivity = .5f;

    RigidbodyFirstPersonController fpsController;
    bool isZoomedInToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        _camera = FindObjectOfType<Camera>();
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
        // retical = FindObjectOfType<Canvas>();
    }

    private void OnDisable()
    {
        ZoomOutCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isZoomedInToggle = !isZoomedInToggle;
        }

        if (isZoomedInToggle)
        {
            ZoomInCamera();
        }
        else
        {
            ZoomOutCamera();
        }
    }


    void ZoomInCamera()
    {
        _camera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
        // FindObjectOfType<WeaponSwitcher>().enabled = false;

        retical.scaleFactor = 7;

    }
    void ZoomOutCamera()
    {
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
        // FindObjectOfType<WeaponSwitcher>().enabled = true;
        _camera.fieldOfView = zoomedOutFOV;
        retical.scaleFactor = 1;
    }
}
