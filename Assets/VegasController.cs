using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegasController : MonoBehaviour
{
    float speed;
    float time;
    Rigidbody body;
    Vector3 originalPos;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        speed = 1.5f;
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(animator.GetBool("hitByCar")))
            body.transform.Translate(speed * Time.deltaTime * Vector3.forward);
        if (time >= 15.0f)
        {
            gameObject.transform.position = originalPos;
            time = 0.0f;
        }
        time = time + Time.deltaTime;
    }
}
