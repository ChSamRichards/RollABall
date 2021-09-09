using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.SceneManagement;

public class PlayerMovement4 : MonoBehaviour
{
    /// <summary>
    /// used unity asset Bezier Path Creator for this scene
    /// </summary>
    
    //accessing PathCreator from the namespace PathCreation from Bezier Path Creator Asset
    public PathCreator pathcreator;
    public float speed = 10f;
    float distance;
   
    // Update is called once per frame
    void Update()
    {

        distance += speed * Time.deltaTime;
        //Moving the player to the point at a distance calculated from above line.
        transform.position = pathcreator.path.GetPointAtDistance(distance);
    }

    public void ReloadMainScene()
    {
        //to load mains scene
        SceneManager.LoadScene("UI");
    }
}
