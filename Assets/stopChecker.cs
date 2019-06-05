using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stopChecker : MonoBehaviour
{
    float time;
    float timer;
    bool shouldStop;
    bool didntStop;
    Text ourComponent2;
    GameObject myTextgameObject2;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        timer = 0.0f;
        shouldStop = false;
        didntStop = false;
        myTextgameObject2 = GameObject.Find("Text2");
        ourComponent2 = myTextgameObject2.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldStop)
            time = time + Time.deltaTime;
        if (didntStop)
        {
            carController.isDriving = false;
            ourComponent2.color = Color.red;
            ourComponent2.text = "You ran the stop sign. Starting Over...";

            Debug.Log("You ran the stop sign! Starting over...");
        }

        if (didntStop && timer > 3)
        {
            carController.isDriving = true;
            ourComponent2.color = Color.red;
            ourComponent2.text = "You ran the stop sign. Starting Over...";

            Debug.Log("You ran the stop sign! Starting over...");
            SceneManager.LoadScene("SampleScene");
        }
        timer = timer + Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        shouldStop = true;
    }

    void OnTriggerExit(Collider collision)
    {
        if(time < 4.0f)
        {
            didntStop = true;
            timer = 0.0f;
        }
        shouldStop = false;
        time = 0.0f;
    }
}
