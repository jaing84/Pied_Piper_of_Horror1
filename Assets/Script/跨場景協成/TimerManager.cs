using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text countdownText;
    private Coroutine countdownCoroutine;
    private void OnEnable()
    {
        // 注册场景加载事件
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 注销场景加载事件
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    

        if (scene.name == "H4")
        {
            // 确保 countdownText 绑定正确
            if (countdownText != null)
            {
                StartCountdown();
            }
            else
            {
                // 如果 countdownText 未绑定成功，可以尝试在此处查找
                countdownText = GameObject.Find("前置時間").GetComponent<Text>();
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
        // 启动倒计时协程
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        int countdownTime = 3;

        while (countdownTime >=0)
        {
            countdownText.text =  countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownText.gameObject.SetActive(false);


        Debug.Log("Countdown finished! Starting coroutine...");


      //StopCountdown();
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
