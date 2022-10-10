using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag=="Player")
        {
            SceneManager.LoadScene("End Menu");
            Debug.Log("End the game");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player")
        {
                SceneManager.LoadScene("End Menu");
            Debug.Log("End the game");
        }
    }
}
