using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement3 : MonoBehaviour
{

    public GameObject[] PathNode;
    public GameObject Player;
    public float MoveSpeed;
    float Timer;
    public Vector3 CurrentPositionHolder;
    public int CurrentNode;
    private Vector3 startPosition;
    

    // Use this for initialization
    void Start()
    {
        
        CheckNode();
    }

    //updates present and next position of player
    void CheckNode()
    {
        Timer = 0;
        startPosition = Player.transform.position; //player starting position
        CurrentPositionHolder = PathNode[CurrentNode].transform.position; // player updated position
       
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;

        //if player is not in updated position or next node position
        //Lerp the positions from player present position to next position
        if (Player.transform.position != CurrentPositionHolder)
        {
            
            if(CurrentNode == 2 )
            {
                //lerping three nodes 2,3,4 to obtain curve or elevation path from 2nd to 4th node point node points
                Player.transform.position = Vector3.Lerp(Vector3.Lerp(startPosition, PathNode[3].transform.position, Timer)
                    , Vector3.Lerp(PathNode[3].transform.position, PathNode[4].transform.position, Timer), Timer);
                CurrentNode++;
            }
            else if(CurrentNode == 10)
            {
                //lerping three nodes 10, 11, 12 to obtain curve or elevation path from 10nd to 12th node point node points
                Player.transform.position = Vector3.Lerp(Vector3.Lerp(startPosition, PathNode[11].transform.position, Timer)
                    , Vector3.Lerp(PathNode[11].transform.position, PathNode[12].transform.position, Timer), Timer);
                CurrentNode++;
            }
            else
            {
                //Lerp the positions from player present position to next position
                Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
            }
           
        }
        else
        {

            if (CurrentNode < PathNode.Length - 1)
            {
                //incrementing next position till last node and again calling the checknode funtion
                CurrentNode++;
                CheckNode();
            }
        }
    }

    public void ReloadMainScene()
    {
        SceneManager.LoadScene("UI");
    }

}