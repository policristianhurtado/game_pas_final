using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single9 : MonoBehaviour
{
      public static Single9 inst;

   void Awake(){
       
        if (Single9.inst == null)
        {
        Single9.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
