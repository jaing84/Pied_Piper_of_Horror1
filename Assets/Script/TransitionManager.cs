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

        //設置新場景的激活場景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        yield return Fade(0);
    }
    /// <summary>
    /// 淡入淡出場景
    /// </summary>
    /// <param name="targetAlpha">1是黑0是白</param>
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
    public void CloseAllButtonSets(GameObject 功能panple)
    {
        if (功能panple != null)
            功能panple.SetActive(false);

    }
}
