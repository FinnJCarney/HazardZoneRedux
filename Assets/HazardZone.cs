using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardZone : MonoBehaviour
{
    public Transform respawnPoint;

    public bool resetScene;
    public int waitTimer;

    GameObject player;
    bool beginTeleport;
    int timer;
   

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            beginTeleport = true;
        }
    }

    public void FixedUpdate()
    {
        if(beginTeleport)
        {
            timer++;
            if(timer > waitTimer)
            {
                beginTeleport = false;
                timer = 0;
                TeleportPlayer();
            }
        }
    }

    public void TeleportPlayer()
    {
        player.transform.position = respawnPoint.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
