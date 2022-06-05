using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : MonoBehaviour
{
    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
