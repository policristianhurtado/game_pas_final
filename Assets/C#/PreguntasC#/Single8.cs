using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single8 : MonoBehaviour
{
      public static Single8 inst;

   void Awake(){
       
        if (Single8.inst == null)
        {
        Single8.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
