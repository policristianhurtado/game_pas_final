using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;
    private Animator transitionAnimator;
    
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        Debug.Log(transitionAnimator);
    }
    
    public void LoadNextScene(int scene)
    {
        StartCoroutine(SceneLoad(scene));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}

