using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    public string startScene;
    private bool isFade;


    private void Start()
    {
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }
    public void Transition(string from, string to)
    {
        if (!isFade) 
            StartCoroutine(TransitionToScene(from, to));
    }


    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);
        if (!string.IsNullOrEmpty(from))
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        //�]�m�s�������E������
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        yield return Fade(0);
    }
    /// <summary>
    /// �H�J�H�X����
    /// </summary>
    /// <param name="targetAlpha">1�O��0�O��</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }
    public void CloseAllButtonSets(GameObject �\��panple)
    {
        if (�\��panple != null)
            �\��panple.SetActive(false);

    }
}
