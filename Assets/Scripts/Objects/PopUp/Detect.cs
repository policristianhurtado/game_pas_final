using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WindowsInput;
using Random = System.Random;

public class Detect : MonoBehaviour
{
    public GameObject[] list_prefabs;
    

    private void Start()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col);
        
        if (col.gameObject.tag == "Player")
        {
            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_D);
            inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);
            if (list_prefabs.Length > 0)
            {
                Random rand = new Random();
                int number = rand.Next(0, list_prefabs.Length);
                GameObject message_selected = list_prefabs[number];
                show_message(message_selected);               
            }
        }
    }

    public void show_message(GameObject message_prefab)
    {
        GameObject message = Instantiate(message_prefab);
        message.transform.position = new Vector3(
            this.gameObject.transform.position.x,
            this.gameObject.transform.position.y+2.1f,
            this.gameObject.transform.position.z
            );
        message.transform.SetParent(this.transform);
    }
}
