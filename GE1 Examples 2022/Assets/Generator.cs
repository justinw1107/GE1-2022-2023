using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 6;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        int radius = 1;
        for (int k=0;k<loops;k++)
        {
            int prefabno = (int)(2 * Mathf.PI * radius * k);
            float theta = 2.0f*Mathf.PI/(float)prefabno;
            for (int i=0;i<prefabno;i++)
            {
                Instantiate(prefab, new Vector3(Mathf.Sin(k*radius), Mathf.Cos(k*radius), 0), Quaternion.identity);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*
NOTES

EACH RING IS INCREMENTED BY 6 (6,12,18,24)

*/
