using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single5 : MonoBehaviour
{
      public static Single5 inst;

   void Awake(){
       
        if (Single5.inst == null)
        {
        Single5.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
