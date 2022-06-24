using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectManager : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject itens;

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
        player.GetComponent<Move2D>().SetPlayerHP(3);
        player.GetComponent<Move2D>().SetSpawnPoint(new Vector3(-17, -1, 0));
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        player.GetComponent<Move2D>().SetPlayerHP(3);
        player.transform.position = player.GetComponent<Move2D>().GetSpawnPoint();
        player.GetComponent<Move2D>().AttBatteryHUD();
        Time.timeScale = 1;
        player.GetComponent<Move2D>().SetDeathCounter(player.GetComponent<Move2D>().GetDeathCounter() + 1);

        player.transform.parent = null;
        Destroy(GameObject.FindGameObjectWithTag("BossRoom"));
        Destroy(GameObject.FindGameObjectWithTag("ItensSpawner"));

        GameObject bossSpawn = Instantiate(boss, new(225.94f, -4f,0), Quaternion.identity);
        GameObject itensSpawn = Instantiate(itens, new(0, 0, 0), Quaternion.identity);

        GameObject bosss = GameObject.FindGameObjectWithTag("Boss");
        player.GetComponent<Move2D>().boss = bosss;

        bosss.SetActive(false);
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    /*public void Settings() => Application.OpenURL("https://thaliston.itch.io/");*/
}
