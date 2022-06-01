using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single3 : MonoBehaviour
{
      public static Single3 inst;

   void Awake(){
       
        if (Single3.inst == null)
        {
        Single3.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
