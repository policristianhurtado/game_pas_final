using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] private Color m_correct = Color.black;
    [SerializeField] private Color m_incorrect = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;

    private DB m_DB = null;
    private UI m_UI = null;

    private void Start(){
        m_DB = GameObject.FindObjectOfType<DB>();
        m_UI = GameObject.FindObjectOfType<UI>();

        NextQuestion();
    }

    private void NextQuestion(){
        m_UI.Constructor(m_DB.GetRandom(), GiveAnswer);
    }
    private void GiveAnswer(OptionButton1 optionButton){
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }
    private IEnumerator GiveAnswerRoutine(OptionButton1 optionButton){
        
        optionButton.SetColor(optionButton.Option.correct ? m_correct : m_incorrect);
    
        yield return new WaitForSeconds(m_waitTime);

        if (optionButton.Option.correct)
        {
            Laberinto();
        }else
        {
            NextQuestion();
        }
        
    }
    private void Laberinto(){
        SceneManager.LoadScene(0);
    }
}
