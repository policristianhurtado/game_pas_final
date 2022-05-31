using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using WindowsInput;

public class popup_scene_3 : MonoBehaviour
{
    [SerializeField] private Button _button_1;
    [SerializeField] private Button _button_2;
    [SerializeField] private Text _button_1_text;
    [SerializeField] private Text _button_2_text;
    
    [SerializeField] private Text _popup_number_1;
    [SerializeField] private Text _popup_number_2;
    [SerializeField] private Text _popup_operation;
    [SerializeField] private Text _popup_result;

    public AudioSource clip;
    
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    Vector3 sum = Vector3.zero;
    Vector3 accum = Vector3.zero;
    
    public void Init(
        Transform canvas,
        string popup_number_1,
        string popup_number_2,
        string btn_1_txt,
        string btn_2_txt,
        string operation,
        Action action)
    {
        _popup_number_1.text = popup_number_1;
        _popup_number_2.text = popup_number_2;
        _button_1_text.text = btn_1_txt;
        _button_2_text.text = btn_2_txt;
        _popup_operation.text = operation;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;

        _button_1.onClick.AddListener(() =>
        {
            PlaySoundButtonClick();
            string result = _popup_result.text;
            if (result != "")
            {
                Debug.Log("lleno");
                action();
                Boolean valid = correct_result(Int16.Parse(popup_number_1), Int16.Parse(popup_number_2), operation, Int16.Parse(result));
                Debug.Log(valid);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                sum = new Vector3(2.0f, 0.0f, 0.0f);
                InputSimulator inputSimulator = new InputSimulator();
                if (valid)
                {
                    // player.transform.position += sum;
                    inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_D);
                }
                else
                {
                    // player.transform.position -= sum;
                    inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_A);
                    
                }
                GameObject.Destroy(this.gameObject);
            }
        });
        
        _button_2.onClick.AddListener(() =>
        {
            PlaySoundButtonClick();
            
            Destroy(gameObject, 0.2f);
        });
        
    }

    private bool correct_result(int number_1, int number_2, string operation, int result)
    {
        Boolean valid = false;
        int res = 0;
        switch (operation)
        {
            case "+":
                res = number_1 + number_2;
                break;
            case "-":
                res = number_1 - number_2;
                break;
            case "*":
                res = number_1 * number_2;
                break;
            case "/":
                res = number_1 / number_2;
                break;
        }

        if (res == result)
        {
            valid = true;
        }

        return valid;
    }

    public void PlaySoundButtonClick()
    {
        clip.Play();
    }
}
