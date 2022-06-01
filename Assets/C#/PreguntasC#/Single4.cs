using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single4 : MonoBehaviour
{
      public static Single4 inst;

   void Awake(){
       
        if (Single4.inst == null)
        {
        Single4.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
