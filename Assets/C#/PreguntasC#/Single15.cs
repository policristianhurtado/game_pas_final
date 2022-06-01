using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single15 : MonoBehaviour
{
      public static Single15 inst;

   void Awake(){
       
        if (Single15.inst == null)
        {
        Single15.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
