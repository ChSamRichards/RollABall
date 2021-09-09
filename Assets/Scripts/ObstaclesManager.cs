using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public List<int> RandomObjects = new List<int>();
    public List<int> RandomObjectsSeperate = new List<int>();
    public GameObject[] obstacles;
    public GameObject[] cylinder;
    public GameObject cone, cube, cylindercube;
    public Transform[] obstaclePositions = new Transform[25];
   
    // Start is called before the first frame update
    void Awake()
    {

        //storing numbers from 0 to 24
        for(int i = 0; i < 25; i++)
        {
            RandomObjects.Add(i);
        }
        //randomizing and storing them in another list without repeating them
        for(int i = 0; i < 25; i++)
        {
            int rd = RandomObjects[Random.Range(0, RandomObjects.Count)];
            RandomObjectsSeperate.Add(rd);
            RandomObjects.Remove(rd);

        }

        //Spawning cubes cones and cylinders randomlt at random positions
        for(int i = 0; i < 8; i++)
        {
            Debug.Log(RandomObjectsSeperate[i]);
           cone = Instantiate(obstacles[2], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            
            cone.tag = "cone";
        }
        for (int i = 8; i < 16; i++)
        {
            Debug.Log(RandomObjectsSeperate[i]);
            cube = Instantiate(obstacles[0], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            cube.tag = "cube";
        }
        for (int i = 16; i < 25; i++)
        {
            Debug.Log(RandomObjectsSeperate[i]);
            //storing cylinders in an array to change them individually when colided with ball to cube
            cylinder[i-16] = Instantiate(obstacles[1], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            cylinder[i-16].tag = "cylinder";
        }
    }
    public void ChngeCylinderToCube(string cyldercuber)
    {
        for(int i = 0; i<9; i++)
        {
            //if collided obstacled name is equal to any of the objects name in cylinders array
            if(cyldercuber == cylinder[i].name)
            {
                Destroy(cylinder[i]);// Destroy and instantiate cube of different color
                cylinder[i] = Instantiate(cylindercube, obstaclePositions[RandomObjectsSeperate[i+16]].position, Quaternion.identity);
            }
        }
    }

  
  
}
