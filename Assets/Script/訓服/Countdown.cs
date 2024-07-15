using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Countdown1 : MonoBehaviour
{
    public Text timerText;
    public float timeRemaining = 90f;
    private bool isPaused = false;
    private Coroutine countdownCoroutine;
    void Start()
    {
        StartCountdown();
    }

    void StartCountdown()
    {
        // 如果已经有倒计时协程在运行，先停止它
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        // 启动新的倒计时协程
        countdownCoroutine = StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            UpdateTimerDisplay(timeRemaining);
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        HandleTimeUp(); // 倒计时结束时的处理
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = Mathf.RoundToInt(time).ToString();
    }

    void HandleTimeUp()
    {
        // 在这里处理倒计时结束时的逻辑
        Debug.Log("Time's up!");
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}

