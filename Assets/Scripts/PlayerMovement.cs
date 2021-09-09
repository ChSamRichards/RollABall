using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    float timer = 5f;
    double sec;
    public Image HealthBar;
    public Material[] materials = new Material[3];
    public Text timeleft;
    Rigidbody rb;
   // public string cylindertocube;
    int cubeCollision = 0;

    public ObstaclesManager obstacleManager;

   void Start()
   {
        rb = GetComponent<Rigidbody>();
        obstacleManager = FindObjectOfType<ObstaclesManager>();
   }
    //Update is called once per frame  
    void FixedUpdate()
    {
        //use WASD or Arrow keys for player movement

        //to move player left side
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            rb.AddForce(Vector3.left * speed);
        }
        //to move player right side
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
           
            rb.AddForce(Vector3.right * speed);
        }



        //to move player forward 
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            
            rb.AddForce(Vector3.forward * (-speed));
        }
        //to move player backward side
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            
            rb.AddForce(Vector3.forward * (speed));
        }



    }

    public void Update()
    {
        //rigidbody's isKinematic becomes true on collision with cone
        if(rb.isKinematic)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                //decreasing image's fill amount completely within a span of 5 seconds
                HealthBar.fillAmount -= 1.0f / 5 * Time.deltaTime;

                //holding timer's seconds value upto two digits in sec variable
                sec = System.Math.Round(timer % 60);

                //converting double to text and showing in timeleft text
                timeleft.text = sec.ToString("0");
            }
                
            else if (timer <= 0)
            {
                //disabling timeleft, restarting timer, sec and player's kinematic is made false
               
                timeleft.enabled = false;
                timer = 0;
                sec = 0;
               
                rb.isKinematic = false;
            }
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "cone")
        {
            Destroy(other.gameObject);
            //enabling timeleft text to show time;
            timeleft.enabled = true;
            timer = 5f;
            //Images fill amount made 1 to reduce completely in update function
            HealthBar.fillAmount = 1f;
            rb.isKinematic = true;
           
           
        }
        if(other.gameObject.tag == "cube")
        {
            //incrementing int to change respective colors from red to blue to green, blue is 1, green is 2
            cubeCollision++;
            if (cubeCollision == 1)
                other.gameObject.GetComponent<Renderer>().material = materials[0];
            else if (cubeCollision >= 2)
                other.gameObject.GetComponent<Renderer>().material = materials[1];



        }
        if(other.gameObject.tag == "cylinder")
        {
            
           //change name of cloned cylinder
            other.gameObject.name = "cylindertocube";
            //calling obstaclemanager to switch from cylinder to cube by passing its name
            obstacleManager.ChngeCylinderToCube(other.gameObject.name);



        }

    }

    public void ReloadMainScene()
    {
        SceneManager.LoadScene("UI");
    }
   

}