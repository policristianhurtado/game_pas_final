using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single11 : MonoBehaviour
{
      public static Single11 inst;

   void Awake(){
       
        if (Single11.inst == null)
        {
        Single11.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
