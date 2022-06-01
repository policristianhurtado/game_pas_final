using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons inst;
   void Awake(){
        if (Singletons.inst == null)
        {
        Singletons.inst = this;
        DontDestroyOnLoad(gameObject);
        }else
        {
        Destroy(gameObject);
        }
   }
}
