using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class speedometer : MonoBehaviour
{
    public Rigidbody car;
    //public CharacterController player;
    GameObject myTextgameObject;
    GameObject myTextgameObject2;
    GameObject scoreDisplay;
    Text ourComponent;
    Text ourComponent2;
    Text scoreText;
    private int counter = 0;
    float time;
    Animator animator;
    Rigidbody bvBody;
    bool crashed;
    Vector3 previous;
    float score = 0;
    float DistanceTravelled = 0;
    Vector3 lastPosition;



    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
        myTextgameObject = GameObject.Find("Text");
        myTextgameObject2 = GameObject.Find("Text2");
        scoreDisplay = GameObject.Find("score");
        ourComponent = myTextgameObject.GetComponent<Text>();
        ourComponent2 = myTextgameObject2.GetComponent<Text>();
        scoreText = scoreDisplay.GetComponent<Text>();
        time = 0.0f;
        crashed = false;
        lastPosition = transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        DistanceTravelled = Vector3.Distance(transform.position, lastPosition);
        score += (DistanceTravelled);
        scoreText.text = " Score: " + (int)score;
        lastPosition = transform.position;

        if (counter % 5 == 0)
        {

            var mph = (int)(((transform.position - previous).magnitude) / (Time.deltaTime * 8));
            previous = transform.position;

            //Debug.Log(car.velocity.magnitude);
            if (mph > 25)
            {
                ourComponent.color = Color.red;
                ourComponent2.color = Color.red;
                ourComponent.text = mph + " MPH ";
                ourComponent2.text = "Slow Down!";
                score -= (int)(12*(DistanceTravelled));



            }
            else
            {
                ourComponent.color = Color.white;

                ourComponent.text = mph + " MPH";
                ourComponent2.color = Color.white;

                ourComponent2.text = " ";
            }
        }
        if (crashed)
        {
            carController.isDriving = false;
            ourComponent2.color = Color.red;
            ourComponent2.text = "You Crashed. Starting Over...";

            Debug.Log("You Crashed! Starting over...");
        }

        if (crashed && time > 3)
        {
            carController.isDriving = true;
            ourComponent2.color = Color.red;
            ourComponent2.text = "You Crashed. Starting Over...";

            Debug.Log("You Crashed! Starting over...");
            SceneManager.LoadScene("SampleScene");
        }

        time = time + Time.deltaTime;
       
        
    }

    void OnTriggerEnter(Collider other)
    {
        string objectName = other.name;
        if(objectName.Contains("bigvegas"))
        {
            animator = other.GetComponent<Animator>();
            bvBody = other.GetComponent<Rigidbody>();
            animator.SetBool("hitByCar", true);
            
        }
        
        Debug.Log("You Crashed! Starting over...");
        
        time = 0.0f;
        if (!(objectName.Contains("stopChecker")))
        {
            crashed = true;
        }
            
        //car.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        //bvBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

    }
    
}
