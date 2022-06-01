using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single17 : MonoBehaviour
{
      public static Single17 inst;

   void Awake(){
       
        if (Single17.inst == null)
        {
        Single17.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
