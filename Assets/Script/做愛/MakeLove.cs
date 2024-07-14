using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakeLove : MonoBehaviour
{
   
    public Sprite[] images;
    public Sprite top;
    public Sprite bottom;
    public Sprite left;
    public Sprite right;
    public Image displayImage;
    public Text scoreText;
    private int score = 0;
    public Text timerText;
    public float timeRemaining = 90f;
    private bool isCountingDown = false;
    private Imagespeed imagespeed;
    public int combo;
    public Text combotext;
    public Image 判定圖2;
    public Sprite prefectSprite;
    public Sprite niceSprite;
    public Sprite badSprite;
    public Sprite nullSprite;
    public Image 施主你早射;
    public int 秒分數 = 0;
    private int initialScore = 0;
    public Image Bar;
    public float health = 0;
    public float maxHealth = 50;
    public float _lerpSpeed = 30;
    public GameObject RandomMove;
    public GameObject panel1;
    private RectTransform panelRect;
    public GameObject 結算;
    private bool isPaused = false;
    public float 數字;
    public float badSpriteCount = 0;
    private Coroutine countdownCoroutine;
    // 搬家 imagespeed 程式

    public RectTransform image2;
    public float speed;
    public float numbleValue1 = 1.7f;
    public bool 判定上下左右1Called = false;
    TimerManager timerManager;
  //  private bool gamePaused  = false;
    void Start()
    {
        timerManager = GameObject.FindObjectOfType<TimerManager>();
        if (timerManager == null)
        {
            Debug.LogError("TimerManager not found in the scene!");
        }
        DisplayRandomImage();
        StartCountdown();
        //  StartCoroutine(Countdown());
        panelRect = panel1.GetComponent<RectTransform>();
        timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
    }

    void StartCountdown()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
        }
    }

    void 到計時() 
    {


        if (isCountingDown)
        {
       
            timeRemaining -= Time.deltaTime;

          
            UpdateTimerDisplay(timeRemaining);

       
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                HandleTimeUp(); 
                isCountingDown = false; 
            }
        }

    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = Mathf.RoundToInt(time).ToString();
    }


    void HandleTimeUp()
    {
        Debug.Log("Time's up!");
        // 在这里处理倒计时结束时的逻辑，比如游戏结束、显示结果等
    }
 
    void CheckAndActivateCanvas()
    {
        GameObject canvasObject = GameObject.Find("做愛UICanvas");
        if (canvasObject != null)
        {
            canvasObject.SetActive(true); // 確保做愛UICanvas是活動的
            imagespeed = canvasObject.GetComponent<Imagespeed>(); // 獲取Imagespeed組件
            if (imagespeed == null)
            {
                Debug.LogError("Imagespeed component not found on 做愛UICanvas!");
            }
        }
        else
        {
            Debug.LogError("做愛UICanvas not found!");
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // ResetTimer();
        Debug.Log("Scene loaded, starting countdown...");
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

      //  CheckAndActivateCanvas();

      //  StartCoroutine(Countdown());
    }


    private void Update()
    {

        if (!timerManager.isGamePaused)
        {
            到計時();
            if (!判定上下左右1Called)
            {
                判定上下左右1();
            }

            UpdateHealthBar();
            HandleInputModeA();
            測試();
            //  imagespeed = GameObject.Find("做愛UICanvas").GetComponent<Imagespeed>();
        }
    }
 
    void HandleInputModeA()
    {
        bool directionCorrect = true;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            directionCorrect = CheckDirection(top);

            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput(top);
            }
            else
            {
                Debug.Log ("測試1");
                ResetCombo();
                HandleBadSprite();
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput(top);
                
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            directionCorrect = CheckDirection(bottom);

            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput(bottom);
            }
            else
            {
                Debug.Log("測試2");
                ResetCombo();
                HandleBadSprite();
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput(bottom);
              
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionCorrect = CheckDirection(left);

            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput(left);
            }
            else
            {
                Debug.Log("測試3");
                ResetCombo();
                HandleBadSprite();
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput(left);
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionCorrect = CheckDirection(right);

            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput(right);
            }
            else
            {
                Debug.Log("測試4");
                ResetCombo();
                HandleBadSprite();
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput(right);
            }

        }

    }
    private void HandleBadSprite()
    {
        判定圖2.sprite = badSprite;
        badSpriteCount++;

        if (badSpriteCount >= 5)
        {
            施主你早射.gameObject.SetActive(true);
            TogglePause();
        }
        else
        {
            StartCoroutine(HideJudgementImage(判定圖2));
        }
    }




  //  private IEnumerator Countdown()
 //   {
 //       while (timeRemaining > 0)
  //      {
  //          Debug.Log("Countdown: " + timeRemaining);
  //          DisplayTime(timeRemaining);
  //          yield return new WaitForSeconds(1f); // 等待一秒鐘
  //          timeRemaining--; // 每過一秒 減1
  //      }


  //      Debug.Log("倒计时结束！");
  //      施主你早射.gameObject.SetActive(true);
   //     TogglePause();
   //     秒分數  +=  1;
  //  }
    void DisplayTime(float timeToDisplay)
    {
        // 更新UI
        timerText.text = Mathf.RoundToInt(timeToDisplay).ToString();
    }


    public void DisplayRandomImage()
    {

        int randomIndex = Random.Range(0, images.Length);


        Sprite randomImage = images[randomIndex];


        displayImage.sprite = randomImage;
    }
   
    void CheckInput(Sprite correctSprite)
    {
        if (displayImage.sprite == correctSprite)
        {

            // 正確加分
            score++;
            scoreText.text =  score.ToString();
            if (判定圖2.sprite == prefectSprite)
            {
                Debug.Log("觸發");
                AddHealth();
                health = Mathf.Min(health, maxHealth);
            }
            else if (判定圖2.sprite == niceSprite)
            {
                niceHealth();
                health = Mathf.Min(health, maxHealth);
            }
            else if (判定圖2.sprite == badSprite)
            {
                RedvceHealth();
                health = Mathf.Max(health, 0);
            }       
            Debug.Log("正確");

        }
        else
        {
            // 錯誤扣分
            score--;
            if (判定圖2.sprite == badSprite)
            {
                RedvceHealth();
            }

            health = Mathf.Max(health, 0);
            scoreText.text =  score.ToString();
            RedvceHealth();
            Debug.Log("錯誤");
        }
        MoveRandomMove();
        // 顯示下一張圖
        DisplayRandomImage();
    }
    
    bool CheckDirection(Sprite correctDirection)
    {
        return displayImage.sprite == correctDirection;
    }


    private void 判定上下左右()
    {
      
        Debug.Log("numbleValue1: " + numbleValue1);
        if (numbleValue1 <= 1.07f && numbleValue1 >= 0.97f)
        {
            // Perfect 范围
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                IncrementCombo();
                判定圖2.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                Debug.Log("測試5");
                badSpriteCount = 0;
            }
        }
        else if (numbleValue1 <= 1.25f && numbleValue1 >= 0.75f)
        {
            // Nice 范围
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // 按键为 Nice
                Debug.Log("Nice!");
                IncrementCombo();
                判定圖2.sprite = niceSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                Debug.Log("測試6");
                badSpriteCount = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                   Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Bad!");
                ResetCombo();
                判定圖2.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖2));

                Debug.Log("測試7");
            }
        }

    }
    private void 判定上下左右1()
    {

        判定上下左右1Called = true;
        if (numbleValue1 < 0.7499f && 判定上下左右1Called)
        {
            Debug.Log(numbleValue1);
            Debug.Log("Bad! (Out of Range)");
            ResetCombo();
            判定圖2.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖2));
            Debug.Log("測試8");
            MoveRandomMove();
            // 顯示下一張圖
            DisplayRandomImage();
            RedvceHealth();
            HandleBadSprite();
            
        }
        判定上下左右1Called = false;
    }


    private IEnumerator HideJudgementImage(Image image)
    {
        yield return new WaitForSeconds(0.3f);
        image.sprite = nullSprite;
    }
    void IncrementCombo()
    {
        combo++;
        combotext.text = "Combo: " + combo.ToString();
    }

    void ResetCombo()
    {
        combo = 0;
        combotext.text = "Combo: " + combo.ToString();
    }
    private void OnDisable()
    {
        score = initialScore;
        UpdateScoreText();
        AddHealth();
    }
    private void UpdateHealthBar()
    {

        float targetFillAmount = health / maxHealth;
        Bar.fillAmount = Mathf.Lerp(Bar.fillAmount, targetFillAmount, _lerpSpeed * Time.deltaTime);

        if(targetFillAmount==1 && Bar.fillAmount > 0.9) 
        {
            Bar.fillAmount = 1;
            結();
        }

        // 測試數字
        數字 = Bar.fillAmount;
    }
    public void AddHealth()
    {
        health += 5;
    }
    public void niceHealth() 
    {
        health += 1;
    }
    public void RedvceHealth()
    {
        health -= 5;
        health = Mathf.Max(health, 0);
    }
    private void UpdateScoreText()
    {
        scoreText.text =  score.ToString();
    }
    public void 結() 
    {
        if (health == maxHealth)
        {
            TogglePause();
            結算.SetActive(true);
        }
    }
    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // 暫停遊戲
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    // 恢復遊戲
    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
    void MoveRandomMove()
    {
        float panelLeft = panelRect.localPosition.x - panelRect.rect.width / 2;
        float panelRight = panelRect.localPosition.x + panelRect.rect.width / 2;
        float panelBottom = panelRect.localPosition.y - panelRect.rect.height / 2;
        float panelTop = panelRect.localPosition.y + panelRect.rect.height / 2;

        // 生成随机位置
        float randomX = Random.Range(panelLeft, panelRight);
        float randomY = Random.Range(panelBottom, panelTop);

        // 限制在指定范围内
        float clampedX = Mathf.Clamp(randomX, panelLeft, panelRight);
        float clampedY = Mathf.Clamp(randomY, panelBottom, panelTop);

        RandomMove.transform.localPosition = new Vector3(clampedX, clampedY, RandomMove.transform.localPosition.z);
    }
    public void 失主早射隱藏()
    {
        TogglePause();
        badSpriteCount = 0;
        timeRemaining = 90f;
        施主你早射.gameObject.SetActive(false);
        
    }
    public void 測試()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
               Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            numbleValue1 = 1.7f;
        }
        else
        {

            if (numbleValue1 >= 0.75)
            {
                numbleValue1 -= 0.1f * Time.deltaTime * speed;
            }
            else
            {
                numbleValue1 = 1.7f;
            }
        }
        Shrink();

    }
    public void Shrink()
    {

        image2.localScale = new Vector3(numbleValue1, numbleValue1, 1f);
        Vector3 newScale2 = image2.localScale;

    }

}
