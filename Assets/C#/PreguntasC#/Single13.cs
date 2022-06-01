using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single13 : MonoBehaviour
{
      public static Single13 inst;

   void Awake(){
       
        if (Single13.inst == null)
        {
        Single13.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
