using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    

    public void LoadMenu() 
    {
        SceneManager.LoadScene("Start Screen 1");
    }
}
