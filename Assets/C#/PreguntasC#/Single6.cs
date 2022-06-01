using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single6 : MonoBehaviour
{
      public static Single6 inst;

   void Awake(){
       
        if (Single6.inst == null)
        {
        Single6.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
