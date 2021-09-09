using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement2 : MonoBehaviour
{

    public float speed;
    public float timer = 0f;
    float countdowntimer = 3f;
    double sec, countdownint;
    public Image HealthBar;
    public bool moved;
    public Text timecompleted, countdowntext;
    Rigidbody rb;
    public ParticleSystem ps;
  
    public GameObject GameWon, healthbarcoverimage, GameLost;


    public CameraController cameraController;
    //use this for initialization  

    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();

        rb = GetComponent<Rigidbody>();
    }
    //Update is called once per frame  
    void FixedUpdate()
    {
        //use WASD or Arrow keys for player movement

        //to move player left side
        //making move true

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
          
            rb.AddForce(Vector3.left * speed); moved = true;
        }
        //to move player right side

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            rb.AddForce(Vector3.right * speed); moved = true;
        }


        //to move player forward 
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            
            rb.AddForce(Vector3.forward * (-speed)); moved = true;
        }
        //to move player backward side
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           
            rb.AddForce(Vector3.forward * (speed)); moved = true;
        }


    }

    public void Update()
    {
        if (moved)
        {
            //if player stays for 30 seconds without colliding
            if (timer >= 30)
            {
                rb.isKinematic = true;
                sec = 0f;
                timecompleted.enabled = false;
                //showing timer and image for gamewon
                healthbarcoverimage.SetActive(true);
                countdowntimer -= Time.deltaTime;
                if(countdowntimer < 0)
                {
                    countdowntimer = 0;
                    countdownint = 0;
                    countdowntext.enabled = false;
                }
                else
                {
                   //showing countdown time 
                    countdownint = System.Math.Round(countdowntimer % 60);
                    countdowntext.text = countdownint.ToString("0");
                    //reducing image fill amount for 3 seonds span 
                    HealthBar.fillAmount -= 1.0f / 3 * Time.deltaTime;
                    if(HealthBar.fillAmount <= 0.004f)
                    {
                        //disabling image after filling is 0
                        healthbarcoverimage.SetActive(false);
                        GameWon.SetActive(true);
                        moved = false;
                    }
                   
                }
                











            }

            else if(timer < 30)
            {
                timer += Time.deltaTime;
               //showing timer value in text
                sec = System.Math.Round(timer % 60);
                timecompleted.text = sec.ToString("00");
               
            }
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        //if player collides with any object excpet walls
        if ((other.gameObject.tag == "cone") || (other.gameObject.tag == "cube") || (other.gameObject.tag == "cylinder")) 
        {

            //camera shake affect for collision and particle system 
            StartCoroutine(cameraController.CamShake());
            
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            rb.isKinematic = true;
            moved = false;
            ps.Play();

            GameLost.SetActive(true);
            

        }
       

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SpawningObjects");
    }
    public void ReloadMainScene()
    {
        SceneManager.LoadScene("UI");
    }
    

}