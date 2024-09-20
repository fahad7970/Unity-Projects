using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject Player;
    private bool playerDestroyed = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Player == null)
        {
            Debug.LogError("Player not found! Make sure the Player is tagged correctly.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name + ", Tag: " + collision.tag);

        if (collision.CompareTag("Border"))
        {
            Debug.Log("Obstacle hit the border, destroying obstacle.");
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            if (!playerDestroyed)
            {
                Debug.Log("Player hit the obstacle, destroying player.");
                playerDestroyed = true;
                Destroy(Player);
            }
        }
        else
        {
            Debug.Log("Collision occurred with: " + collision.gameObject.name + " but no action taken.");
        }
    }
}

