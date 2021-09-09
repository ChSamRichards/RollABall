using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<int> RandomObjects = new List<int>();
    public List<int> RandomObjectsSeperate = new List<int>();
    public GameObject[] obstacles;
    public GameObject[] clones = new GameObject[25];
    public GameObject cone, cube, cylinder;
    public Transform[] obstaclePositions = new Transform[25];
    public PlayerMovement2 playermovement2;
    public bool moved1, moved1opposite;

    // Start is called before the first frame update
    void Awake()
    {
        //Adding 0 to 24 numbers in RandomObjects list
        for (int i = 0; i < 25; i++)
        {
            RandomObjects.Add(i);
        }
        //Getting random numbers from RandomObjects list and storing those from 0 to 24 in RandomObjectsSeperate list
        //in order to avoid repeatition of random numbers
        for (int i = 0; i < 25; i++)
        {
            int rd = RandomObjects[Random.Range(0, RandomObjects.Count)];
            RandomObjectsSeperate.Add(rd);
            RandomObjects.Remove(rd);

        }
        for (int i = 0; i < 25; i++)
        {
           //saving instantiated objects in clones gameobject
            clones[i] = Instantiate(obstacles[Random.Range(0,3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
        }

    }
    void Start()
    {
        //object of PlayerMovement script, accessing bool moved from that script and storing in moved1
        playermovement2 = FindObjectOfType<PlayerMovement2>();
        moved1 = playermovement2.moved;

    }
    void Update()
    {
        //storing the updated  moved bool and storing in moved1
        //gives whether player is in moving or not
        moved1 = playermovement2.moved;

        if (moved1opposite ==false && moved1)
        {
            //spawning objects only when player moves from original position
            InvokeSpawning();
            //to call InvokeSpawing only once, we made condition true
            moved1opposite = true;
        }
       
    }
  
    void InvokeSpawning()
    {
        //Grouped 25 spawning gameobjects into 6 sets, i,e, 4/5 for each set and spawining them randomly
        if (moved1)
        {
            Invoke("DestroySpawnObjects1", 1f);
            Invoke("DestroySpawnObjects2", 2f);
            Invoke("DestroySpawnObjects3", 3f);
            Invoke("DestroySpawnObjects4", 4f);
            Invoke("DestroySpawnObjects5", 5f);
            Invoke("DestroySpawnObjects6", 6f);
            Invoke("RandomNumbersChange", 10f);
        }
        else
        {
            CancelInvoke("DestroySpawnObjects1");
            CancelInvoke("DestroySpawnObjects2");
            CancelInvoke("DestroySpawnObjects3");
            CancelInvoke("DestroySpawnObjects4");
            CancelInvoke("DestroySpawnObjects5");
            CancelInvoke("DestroySpawnObjects6");
            CancelInvoke("RandomNumbersChange");
        }
        
    }


    void RandomNumbersChange()
    {
        //to change random numbers from awake function so that the obstacles randomize among the 6 sets again and again for every 10 seconds
        if (moved1)
        {

            //firstly cancel the invoke of spawining
            CancelInvoke("DestroySpawnObjects1");
            CancelInvoke("DestroySpawnObjects2");
            CancelInvoke("DestroySpawnObjects3");
            CancelInvoke("DestroySpawnObjects4");
            CancelInvoke("DestroySpawnObjects5");
            CancelInvoke("DestroySpawnObjects6");
            CancelInvoke("SpawnObjects1");
            CancelInvoke("SpawnObjects2");
            CancelInvoke("SpawnObjects3");
            CancelInvoke("SpawnObjects4");
            CancelInvoke("SpawnObjects5");
            CancelInvoke("SpawnObjects6");
            //make new random numbers
            for (int i = 0; i < 25; i++)
            {
                Destroy(clones[i]);
            }


            for (int i = 0; i < 25; i++)
            {
                RandomObjects.Add(i);
            }
            for (int i = 0; i < 25; i++)
            {
                int rd = RandomObjects[Random.Range(0, RandomObjects.Count)];
                RandomObjectsSeperate.Add(rd);
                RandomObjects.Remove(rd);

            }
            //assign new random numbers and instantiate objects randomly which are different from previous random numbers
            for (int i = 0; i < 25; i++)
            {
               
                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            //calling this function to spawn again which are cancelled above
            InvokeSpawning();
        }

    }

    /// <summary>
    /// Recursively Invoking Destroying and Spawing funtions of 6 sets randomly till collision happens(moved becomes false) 
    /// </summary>

    //first set of destroying objects 
    void DestroySpawnObjects1()
    {

        if (moved1)
        {
            for (int i = 0; i < 4; i++)
            {
                
                Destroy(clones[i]);

            }
            //spawning first set objects again in 1 to 3 seconds randomly
            Invoke("SpawnObjects1", Random.Range(1, 3));
        }
        else
        {
            
            CancelInvoke("SpawnObjects1");
        }


    }
    //spawning first set objects
    void SpawnObjects1()
    {
        if (moved1)
        {
            for (int i = 0; i < 4; i++)
            {

                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            Invoke("DestroySpawnObjects1", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("DestroySpawnObjects1");
        }
    }

    //Destroying second set objects
    void DestroySpawnObjects2()
    {
        if (moved1)
        {
            for (int i = 4; i < 8; i++)
            {
                Destroy(clones[i]);

            }
            //spawning second set objects
            Invoke("SpawnObjects2", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("SpawnObjects2");
        }
    }

    //spawning second set objects

    void SpawnObjects2()
    {
        if (moved1)
        {
            for (int i = 4; i < 8; i++)
            {

                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            Invoke("DestroySpawnObjects2", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("DestroySpawnObjects2");
        }
    }
    //Destroying third set objects
    void DestroySpawnObjects3()
    {
        if (moved1)
        {
            for (int i = 8; i < 12; i++)
            {
                Destroy(clones[i]);

            }
            //spawning third set objects
            Invoke("SpawnObjects3", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("SpawnObjects3");
        }
    }
    //spawning third set objects
    void SpawnObjects3()
    {
        if (moved1)
        {
            for (int i = 8; i < 12; i++)
            {

                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            Invoke("DestroySpawnObjects3", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("DestroySpawnObjects3");
        }
    }

    //Destroying fourth set objects
    void DestroySpawnObjects4()
    {
        if (moved1)
        {
            for (int i = 12; i < 16; i++)
            {
                Destroy(clones[i]);

            }
            //spawning fourth set objects
            Invoke("SpawnObjects4", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("SpawnObjects4");
        }

    }

    //spawning fourth set objects
    void SpawnObjects4()
    {
        if (moved1)
        {
            for (int i = 12; i < 16; i++)
            {

                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            Invoke("DestroySpawnObjects4", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("DestroySpawnObjects4");
        }
    }

    //Destroying fifth set objects
    void DestroySpawnObjects5()
    {
        if (moved1)
        {
            for (int i = 16; i < 20; i++)
            {
                Destroy(clones[i]);

            }
            //spawning fifth set objects
            Invoke("SpawnObjects5", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("SpawnObjects5");
        }

    }

    //spawning fifth set objects
    void SpawnObjects5()
    {
        if (moved1)
        {
            for (int i = 16; i < 20; i++)
            {

                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            Invoke("DestroySpawnObjects5", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("DestroySpawnObjects5");
        }
    }

    //Destroyinh sixth set objects
    void DestroySpawnObjects6()
    {
        if (moved1)
        {
            for (int i = 20; i < 25; i++)
            {
                Destroy(clones[i]);

            }
            //spawning sixth set objects 
            Invoke("SpawnObjects6", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("SpawnObjects6");
        }

    }

    //spawning sixth set objects
    void SpawnObjects6()
    {
        if (moved1)
        {
            for (int i = 20; i < 25; i++)
            {

                clones[i] = Instantiate(obstacles[Random.Range(0, 3)], obstaclePositions[RandomObjectsSeperate[i]].position, Quaternion.identity);
            }
            Invoke("DestroySpawnObjects6", Random.Range(1, 3));
        }
        else
        {
            CancelInvoke("DestroySpawnObjects6");
        }
    }


}
