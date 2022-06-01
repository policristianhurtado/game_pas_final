using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
     [SerializeField] private AudioClip m_correctSound =null;
     [SerializeField] private AudioClip m_incorrectSound = null;
     [SerializeField] private Color m_correctColor = Color.black;
     [SerializeField] private Color m_incorrectColor = Color.black;
     [SerializeField] private float m_waitTime = 0.0f;

    private QuizDB m_quizDB =null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource =null;

private void Start()
{
m_quizDB= GameObject.FindObjectOfType<QuizDB>();
m_quizUI= GameObject.FindObjectOfType<QuizUI>();
m_audioSource= GetComponent<AudioSource>();

NextQuestions();
}

private void NextQuestions()
{
    m_quizUI.Construtc(m_quizDB.GetRandom(), GiveAnswer);
}

private void GiveAnswer (OptionButton optionButton)
{
StartCoroutine( GiveAnswerRoutine(optionButton));
}

private IEnumerator GiveAnswerRoutine(OptionButton optionButton )
{
if (m_audioSource.isPlaying)
m_audioSource.Stop();


m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
optionButton.setColor( optionButton.Option.correct ? m_correctColor : m_incorrectColor);

m_audioSource.Play();

yield return new  WaitForSeconds (m_waitTime);

NextQuestions();
}


    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    

    public Renderer fondo;
  public bool gameover=false;
  public bool start=false;


    void Update()
    {
 
if(start==false )
{
if (Input.GetKeyDown(KeyCode.X))
{
    start=true;
    
}

}
if(start==true &&gameover==true){

    menuGameOver.SetActive(true);
if (Input.GetKeyDown (KeyCode.X))
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}




        if (start == true && gameover== false)
        {
    menuPrincipal.SetActive(false);

          fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.00f, 0) * Time.deltaTime*300;  
        }
        
    
    }
}
