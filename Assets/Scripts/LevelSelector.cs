using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    //to load beginner mode scene
    public void Beginner()
    {
        SceneManager.LoadScene("RollingBall");
    }
    //to load Intermediate mdoe scene
    public void Intermediate()
    {
        SceneManager.LoadScene("SpawningObjects");
    }
    //To loat Advanced mode scene
    public void Advanced()
    {
        SceneManager.LoadScene("PredinedPathNavmesh 1");
    }

   
    //these scenes are made using lerping and bezier curves 
    public void Advanced1()
    {
        SceneManager.LoadScene("PredinedPath");
    }
    public void Advanced2()
    {
        SceneManager.LoadScene("PredinedPath2");
    }
    public void Applicationquit()
    {
        Application.Quit();
    }


}
