using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour
{
    public static bool isDriving = true;
    float xspeep = 0f;
    float power = 0.04f;
    float friction = 0.85f;
    bool right = false;
    bool left = false;
    Vector3 previous;
    GameObject leftSignal;
    bool leftTurn;
    GameObject rightSignal;
    bool rightTurn;
    bool opposite;
    bool opposite2;
    int counter;


    void Start()
    {
        leftSignal = GameObject.Find("Button");
        rightSignal = GameObject.Find("Button2");
        counter = 0;
    }
    // Use this for initialization
    void FixedUpdate()
    {
        var mph = (int)(((transform.position - previous).magnitude) / (Time.deltaTime * 5));
        previous = transform.position;
        if(!left && !right)
        //if (mph == 0 && power > 0.04f)
        {
            power = 0.005f;

            //Debug.Log(mph);
            if (xspeep > 0.001f)
            {
                //power = 0.04f;
                xspeep -= power;
            }
        }


        if (right)
        {
            xspeep += power;
            power += .0005f;
            
        }
        if (left)
        {
            xspeep -= power;
            //power -= .0005f;
        }


    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        
        
        if(isDriving)
        {
            if (Input.GetKeyDown("w"))
            {
                right = true;
            }
            if (Input.GetKeyUp("w"))
            {
                right = false;
            }
            if (Input.GetKeyDown("s"))
            {
                left = true;
            }
            if (Input.GetKeyUp("s"))
            {
                left = false;
            }
            if (Input.GetKey(KeyCode.D) && xspeep > 0)
            {
                transform.Rotate(0, 0.6f, 0);
            }
            if (Input.GetKey(KeyCode.A) && xspeep > 0)
            {

                transform.Rotate(0, -0.6f, 0);

            }
            if (Input.GetKey(KeyCode.D) && xspeep < 0)
            {
                transform.Rotate(0, 1f, 0);
            }
            if (Input.GetKey(KeyCode.A) && xspeep < 0)
            {

                transform.Rotate(0, -1f, 0);

            }
            if (Input.GetKeyDown(KeyCode.Q) && !leftTurn)
            {
                leftTurn = true;
            }
            if (leftTurn && (counter % 10 == 0))
            {
                opposite = !leftSignal.activeSelf;
                leftSignal.SetActive(opposite);
            }
            if (Input.GetKeyUp(KeyCode.Q) && leftTurn)
            {
                leftTurn = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && !rightTurn)
            {
                rightTurn = true;
            }
            if (rightTurn && (counter % 10 == 0))
            {
                opposite2 = !rightSignal.activeSelf;
                rightSignal.SetActive(opposite2);
            }
            if (Input.GetKeyUp(KeyCode.E) && rightTurn)
            {
                rightTurn = false;
            }


            xspeep *= friction;
            transform.Translate(Vector3.back * -xspeep);
        }

        

    }
}
