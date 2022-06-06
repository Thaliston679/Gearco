using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Quicksand") //Afundar a cabeça na areia movediça
        {
            player.GetComponent<Move2D>().playerHP--;
            player.GetComponent<Move2D>().Respawn();
        }
    }
}
