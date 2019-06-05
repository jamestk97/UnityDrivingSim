using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bvspawner : MonoBehaviour
{
    private float time;
    public GameObject bigVegas;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 20.0f)
        {
            time = 0.0f;
            Instantiate(bigVegas);
        }
        
    }
}
