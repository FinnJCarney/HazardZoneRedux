using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                ResetPlayer();
            }
        }
    }

    public void ResetPlayer()
    {
        if (!resetScene)
        {
            player.transform.position = respawnPoint.position;
            player.GetComponent<CharacterController>().enabled = true;
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
