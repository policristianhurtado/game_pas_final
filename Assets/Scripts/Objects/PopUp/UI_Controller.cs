using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{

    public static UI_Controller Instance;

    public Transform MainCanvas;
    
    // Start is called before the first frame update
     void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public popup_scene_3 CreatePopUp()
    {
        GameObject pop_up_go = Instantiate(Resources.Load("UI/popup") as GameObject);
        return pop_up_go.GetComponent<popup_scene_3>();
    }

    public popup_scene_3 DestroyPopUp()
    {
        GameObject.Destroy(this.gameObject);
        return null;
    }
}
