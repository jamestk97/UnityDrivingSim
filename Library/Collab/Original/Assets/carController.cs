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
                transform.Rotate(0, 1f, 0);
            }
            if (Input.GetKey(KeyCode.A) && xspeep > 0)
            {

                transform.Rotate(0, -1f, 0);

            }
            if (Input.GetKey(KeyCode.D) && xspeep < 0)
            {
                transform.Rotate(0, 1f, 0);
            }
            if (Input.GetKey(KeyCode.A) && xspeep < 0)
            {

                transform.Rotate(0, -1f, 0);

            }


            xspeep *= friction;
            transform.Translate(Vector3.back * -xspeep);
        }

        

    }
}
