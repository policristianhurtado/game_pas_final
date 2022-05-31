using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.PlayerLoop;
using UnityEngine.Audio;
using Random = System.Random;

public class Maths_operations : MonoBehaviour
{
    Random rand = new Random();
    private int number_1 = 0;
    private int number_2 = 0;
    private int result = 0;
    private string operation = "+";
    
    private popup_scene_3 popup;
    public AudioSource clip;
    
    private int get_number_random()
    {
        return rand.Next(0, 20);
    }

    private int get_number_1()
    {
        number_1 = get_number_random();
        // Debug.Log("get_number_1: " + number_1);
        return number_1;
    }

    private int get_number_2()
    {
        number_2 = get_number_random();
        // Debug.Log("get_number_2: " + number_2);
        return number_2;
    }

    private string get_operation(int num_1, int num_2)
    {
        string operation = "";
        int number;
        string[] list_operations = {"+", "*", "-","/"};

        if (num_2 == 0)
        {
            number = rand.Next(0, 3);
            operation = list_operations[number];
        }
        else
        {
            if (num_1 % num_2 == 0)
            {
                number = rand.Next(0, 4);
                operation = list_operations[number];
            }else if (num_1 < num_2)
            {
                number = rand.Next(0, 2);
                operation = list_operations[number];
            }
            else
            {
                number = rand.Next(0, 3);
                operation = list_operations[number];
            }
        }

        return operation;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
        Action action = () =>
        {
            Camera.main.backgroundColor = UnityEngine.Random.ColorHSV();
        };

        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            PlaySoundButtonClick();
            popup_scene_3 popup = UI_Controller.Instance.CreatePopUp();
            int num_value_1 = get_number_1();
            int num_value_2 = get_number_2();
            
            popup.Init(
                UI_Controller.Instance.MainCanvas,
                num_value_1.ToString(),
                num_value_2.ToString(),
                "Seguro !!",
                "Cancelar",
                get_operation(num_value_1, num_value_2),
                action
            );
        });
        
    }

    private void PlaySoundButtonClick()
    {
        clip.Play();
    }
}
