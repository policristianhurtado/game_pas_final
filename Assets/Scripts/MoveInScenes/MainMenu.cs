using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private LoadSceneManager loadSceneManager;
    public string inputValue;
    private int count_users;
    private string nickname;
    private string nicknamePrefsName = "nickname";
    
    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        loadSceneManager = GameObject.FindGameObjectWithTag("SceneLoad").GetComponent<LoadSceneManager>();
        // Debug.Log(loadSceneManager);
    }

    public void EnterKickName(string nickname)
    {
        inputValue = nickname;
        // Debug.Log(inputValue);
    }
    
    public void Jugar()
    {
        if (inputValue == null)
        {
            inputValue = "Unknown";
        }

        // count_users = list_players.Count + 1;
        // Debug.Log(count_users);
        //
        // list_players.Add(count_users, inputValue);

        int active_scene = SceneManager.GetActiveScene().buildIndex;
        loadSceneManager.LoadNextScene(active_scene + 1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Debug.Log(inputValue);
    }

    public void SaveData()
    {
        Debug.Log(nickname);
        PlayerPrefs.SetString(nicknamePrefsName, nickname);
    }

    public void OnDestroy()
    {
        SaveData();
    }

    public void LoadData()
    {
        nickname = PlayerPrefs.GetString(nicknamePrefsName, "unknow");
        Debug.Log(nickname);
    }
    
}
