using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single16 : MonoBehaviour
{
      public static Single16 inst;

   void Awake(){
       
        if (Single16.inst == null)
        {
        Single16.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
