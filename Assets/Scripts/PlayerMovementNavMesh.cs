using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementNavMesh : MonoBehaviour
{
    /// <summary>
    /// Automatic path finding using Unity's Nav Mesh feature
    /// </summary>
    public Transform[] positions;
    //public Transform currentnode;
    //player is the navmeshagent
    public NavMeshAgent navmeshagent;
    public int presentNode;
    public Material[] mats;
    float timer;
    public Text navmeshtext;
    float countdown = 2f;
    public GameObject GameOver;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        //making player's destination to the next position
        navmeshagent.destination = positions[presentNode].position;
    }

    // Update is called once per frame
    void Update()
    {
        //distance from present position to next position

        // using distance instead of positions to avoid stopping of agent at every waypoint or destination
        float dist = Vector3.Distance(positions[presentNode].position, transform.position);

        
     
        if (dist < 1)
        {
            if (presentNode < positions.Length - 1)
            {
                //incrementing present  node
                presentNode++;
                //agents destination is made to next next node
                navmeshagent.destination = positions[presentNode].position;
                
            }

        }
        if (presentNode < positions.Length - 1)
        {

            timer += Time.deltaTime;
            //showing timer in navmeshtext text object
            navmeshtext.text = System.Math.Round(timer, 0).ToString();

            //if timer exceeds 15 seconds
            if (timer > 15)
            {
                timer = 15;
                //player speed is 0, it stops
                navmeshagent.speed = 0f;
                
                countdown -= Time.deltaTime;    //countdown time form agent to startmoving again
                if (countdown <= 0)
                {
                    StartCoroutine(Playparticles());
                    //changing player material for every 15 seconds after particle system plays
                    navmeshagent.GetComponent<Renderer>().material = mats[Random.Range(0, 5)];
                    navmeshagent.speed = 4f;         //making player move again
                    timer = 0f;                     //resetting timer and countdown
                    countdown = 2f;
                }


            }


        }
        else
        {
            //showing present time even after player moves. timer dont get updated but shows stopped time.
            navmeshtext.text = System.Math.Round(timer, 0).ToString();
            GameOver.SetActive(true);
        }






    }
    public IEnumerator Playparticles()
    {
        //playing particlesystem for 10 seconds
        ps.Play();
        yield return new WaitForSeconds(10f);
        ps.Stop();
    }
    public void MainScene()
    {
        SceneManager.LoadScene("UI");
    }

    public void Replay()
    {
        SceneManager.LoadScene("PredinedPathNavmesh 1");
    }

}
