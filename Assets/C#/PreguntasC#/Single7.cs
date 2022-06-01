using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single7 : MonoBehaviour
{
      public static Single7 inst;

   void Awake(){
       
        if (Single7.inst == null)
        {
        Single7.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
