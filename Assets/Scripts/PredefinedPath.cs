using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredefinedPath : MonoBehaviour
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
        //PathNode = GetComponentInChildren<>();
        CheckNode();
    }

    void CheckNode()
    {
        Timer = 0;
        startPosition = Player.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;

        if (Player.transform.position != CurrentPositionHolder)
        {


            Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {

            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }
}