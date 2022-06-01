using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single10 : MonoBehaviour
{
      public static Single10 inst;

   void Awake(){
       
        if (Single10.inst == null)
        {
        Single10.inst = this;
        DontDestroyOnLoad(gameObject);
        
        }else
        {
        Destroy(gameObject);
        }
   }
}
