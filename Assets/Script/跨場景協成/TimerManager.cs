using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text countdownText;
    private Coroutine countdownCoroutine;
    public bool Opennice = true;
    public bool isPreparationCountdown = false;
    public bool isGamePaused = false;
    // private bool isCountingDown = false;
    private void OnEnable()
    {
        // 瘜典??箸?蝸鈭辣
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 瘜券??箸?蝸鈭辣
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    

        if (scene.name == "H4")
        {
            // 蝖桐? countdownText 蝏?甇?＆
            if (countdownText != null)
            {
                StartCountdown();
            }
            else
            {
                // 憒? countdownText ?芰?摰????臭誑撠??冽迨憭??
                countdownText = GameObject.Find("?蔭??").GetComponent<Text>();
                if (countdownText != null)
                {
                    StartCountdown();
                }
                else
                {
                    Debug.LogError("CountdownText not found in scene H4");
                }
            }
        }
    }
    private void StartCountdown()
    {
        // ?臬?恣?嗅?蝔?
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        isPreparationCountdown = true;
        countdownCoroutine = StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        countdownText.gameObject.SetActive(true);
        int countdownTime = 3;
        // isCountingDown = true;
        // Opennice = true;
        isGamePaused = true;
        while (countdownTime >=0)
        {
          
            countdownText.text =  countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownText.gameObject.SetActive(false);
        //  isCountingDown = false;
        // Opennice = false;
        isGamePaused = false;
        isPreparationCountdown = false;
        Debug.Log("Countdown finished! Starting coroutine...");


      //StopCountdown();
    }

    public bool IsPreparationCountdown()
    {
        return isPreparationCountdown;
    }

    public bool IsGamePaused()
    {
        return isGamePaused;
    }
    private void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }

}

