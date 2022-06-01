using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single19 : MonoBehaviour
{
      public static Single19 inst;

   void Awake(){
       
        if (Single19.inst == null)
        {
        Single19.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
