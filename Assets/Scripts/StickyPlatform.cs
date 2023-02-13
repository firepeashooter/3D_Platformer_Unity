using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class deals with the moving platforms, and makes sure the player moves with them

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
       if (collision.gameObject.name == "Player") //If its colliding with the player, it makes the player a child which makes it move with the platform
       {
           collision.gameObject.transform.SetParent(transform);
       } 
    }

    private void OnCollisionExit(Collision collision) //This removes the player as a child
    {
        collision.gameObject.transform.SetParent(null);
    }
}
