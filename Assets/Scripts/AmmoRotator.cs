using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRotator : MonoBehaviour
{
    // Start is called before the first frame updat
    public float minimum = -0.000001F;
    public float maximum =  0.0000010F;

    public float rotationSpeed=2;

    // starting value for the Lerp
    static float t = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed*Time.deltaTime, 0);

        transform.position = new Vector3(transform.position.x,transform.position.y + Mathf.Lerp(minimum, maximum, t), transform.position.z);

        // .. and increase the t interpolater
        t += 0.1f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
