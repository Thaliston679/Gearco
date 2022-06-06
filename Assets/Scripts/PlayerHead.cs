using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public GameObject batteryHUD;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Quicksand") //Afundar a cabeça na areia movediça
        {
            player.transform.position = player.GetComponent<Move2D>().GetSpawnPoint();
            int hp = player.GetComponent<Move2D>().GetPlayerHP();
            player.GetComponent<Move2D>().SetPlayerHP(hp-1);
            player.GetComponent<Move2D>().AttBatteryHUD();
        }
    }
    /*
    public void Respawn()
    {
        if (this.transform.position.y < -10) //"Morte"
        {
            this.transform.position = spawnPoint;
            playerHP--;
            batteryHUD.GetComponent<BatteryHUD>().HPBattery(playerHP);
        }
    }
    */
}
