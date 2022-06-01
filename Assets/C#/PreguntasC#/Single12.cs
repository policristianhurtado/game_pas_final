using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single12 : MonoBehaviour
{
      public static Single12 inst;

   void Awake(){
       
        if (Single12.inst == null)
        {
        Single12.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
