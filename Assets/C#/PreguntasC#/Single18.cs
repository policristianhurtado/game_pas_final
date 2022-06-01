using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single18 : MonoBehaviour
{
      public static Single18 inst;

   void Awake(){
       
        if (Single18.inst == null)
        {
        Single18.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
