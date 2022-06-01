using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single2 : MonoBehaviour
{
      public static Single2 inst;

   void Awake(){
       
        if (Single2.inst == null)
        {
        Single2.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
