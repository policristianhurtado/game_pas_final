using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<OptionButton1> m_buttonList = null;

    public void Constructor(Question q, Action<OptionButton1> callback){

        m_question.text = q.text;
        
        for (int i = 0; i < m_buttonList.Count; i++)
        {
            m_buttonList[i].Constructor(q.options[i], callback);
        }
    }
}
