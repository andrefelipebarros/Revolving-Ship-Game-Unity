using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void Update()
    {
        Time.timeScale = 1f;
        if (Input.anyKeyDown){
            Application.LoadLevel("SampleScene");
        }
        
    }

}
