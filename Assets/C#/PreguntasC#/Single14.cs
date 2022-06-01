using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single14 : MonoBehaviour
{
      public static Single14 inst;

   void Awake(){
       
        if (Single14.inst == null)
        {
        Single14.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
