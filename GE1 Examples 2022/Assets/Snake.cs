using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Transform head;

    public Transform tail;
    [Range(0, 5)]

    public float frequency = 0.5f;

    public int headAmplitude = 40;

    public int tailAmplitude = 60;

    public float theta;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theta = Time.time * frequency;

        float headAngle = headAmplitude * Mathf.Sin(theta);
        float tailAngle = tailAmplitude * Mathf.Sin(theta);

        head.localRotation = Quaternion.AngleAxis(headAngle, Vector3.forward);
        tail.localRotation = Quaternion.AngleAxis(tailAngle, Vector3.forward);

    }
}
