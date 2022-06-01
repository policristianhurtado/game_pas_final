using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{
    private LoadSceneManager loadSceneManager;

    private void Start()
    {
        loadSceneManager = GameObject.FindGameObjectWithTag("SceneLoad").GetComponent<LoadSceneManager>();
        Debug.Log(loadSceneManager);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entro");
        if (col.gameObject.tag == "Player")

        {
            Debug.Log("prueba");
            loadSceneManager.LoadNextScene(3); //LoadNextScene();
        }
    }
}
