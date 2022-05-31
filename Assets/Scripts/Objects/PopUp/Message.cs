using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WindowsInput;
using UnityEngine.Audio;

public class Message : MonoBehaviour
{

    public float time_live = 4;
    public AudioSource clip;

    private void Start()
    {
        Debug.Log(gameObject.name);
        // Debug.Log(GameObject.Find(gameObject.name + "(clone)"));
        clip.Play();
    }

    private void Update()
    {
        time_live -= Time.deltaTime;
        if (time_live <= 0)
        {
            Destroy(this.gameObject);
        }
        // transform.position = transform.parent.position;
    }
}
