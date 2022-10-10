using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoAnim : MonoBehaviour
{
    // Start is called before the first frame update
    static float t = 0.0f;
    public float minimum = -0.0000001F;
    public float maximum = 0.0000001F;
    float startPos;
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
        transform.position = new Vector3(transform.position.x, startPos + Mathf.Lerp(minimum, maximum, t), transform.position.z);
        t += 0.3f * Time.deltaTime;
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
