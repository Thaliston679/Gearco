using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : MonoBehaviour
{
    public GameObject player;

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

    public void ExitGame() => Application.Quit();

    public void Restart()
    {
        player.gameObject.GetComponent<Move2D>().SetPlayerHP(3);
        player.gameObject.GetComponent<Move2D>().SetSpawnPoint(new Vector3(-17, -1, 0));
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    /*public void Settings() => Application.OpenURL("https://thaliston.itch.io/");*/
}
