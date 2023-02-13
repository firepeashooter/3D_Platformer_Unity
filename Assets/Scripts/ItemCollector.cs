using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




//This class deals with what happens when the player collects an item

public class ItemCollector : MonoBehaviour
{
    [SerializeField] Text coinsText; //Creates a connection to the UI coin counter
    [SerializeField] AudioSource collectionSound;
    int coins = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Coin")) //When colliding with a coin...
        {
            Destroy(other.gameObject);
            coins ++;
            coinsText.text = "Coins: " + coins;
            collectionSound.Play();
        }
    }
}
