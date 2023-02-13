using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class deals with the life of the player

public class PlayerLife : MonoBehaviour
{
    public GameObject player;
    [SerializeField] AudioSource deathSound;
    bool dead = false;
    private void Update() 
    {
        if (transform.position.y < -1 && !dead) 
        {
            Die();
        }

    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy")) //Deals with the collision of an enemy
        {
            player.GetComponent<SkinnedMeshRenderer>().enabled = false;  //Gets rid of the skin of the model
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
          
        }
    }

    void Die() 
    {
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true; 
        deathSound.Play();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
