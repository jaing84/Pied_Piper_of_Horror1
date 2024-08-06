using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public Image 判定圖2; public Image 判定圖3;
    public Sprite prefectSprite;
    public Sprite niceSprite;
    public Sprite badSprite;
    public Sprite nullSprite;
    public Image 施主你早射;
    public int 秒分數 = 0;
    private int initialScore = 0;
    public Image Bar;
    public float health = 0;
    public float maxHealth = 100;
    public float coinbutton = 0;
    public float maxcoinbutton = 100;
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
    //1
    public RectTransform image3; 
    public RectTransform image4;
    //2
    public RectTransform image5;
    public RectTransform image6;
    //3
    public RectTransform image7;
    public RectTransform image8;
    //4
    public RectTransform image9;
    public RectTransform image10;
    public float speed;
    public float speed1;
    public float numbleValue1 = 1.7f;
    public float numbleValue2 = 1.7f;
    public float numbleValue3 = 1.3f;
    public float numbleValue4 = 1.7f;
    public float numbleValue5 = 1.7f;
    public float numbleValue6 = 1.7f;
    public bool 判定上下左右1Called = false;
    TimerManager timerManager;
    //  private bool gamePaused  = false;
    public bool 協成開始 = false;
    public bool 預測值 = false;
    //cg圖
    public GameObject spicel1;
    public GameObject spicel2;
    public Text spicetext1;
    public Text spicetext2;
    public GameObject quimage1;
    public GameObject quimage2;
    public GameObject quimage3;
    public GameObject quimage4;
    public bool opengame = false;
    public bool opengame1 = false;
    public bool opengame2 = false;
    public bool opengame3 = false;
    public bool opengame4 = false;
    public GameObject CGGame;
    public Sprite CG1;
    public Sprite CG2;
    public Sprite CG3;
    public Sprite CG4;
    public Sprite CG5;
    public Sprite CG6;
    public Sprite CG7;
    public Sprite CG8;
    public Sprite CG9;
    public Sprite CG10;
    public Sprite CG11;
    public Sprite CG12;
    public Sprite CG13;
    public Sprite CG14;
    public Sprite CG15;
    public Sprite CG16;
    public Sprite CG17;
    public Sprite CG18;
    public Sprite CG19;
    public Sprite CG20;
    public Sprite CG21;
    public Sprite CG22;
    public Sprite CG23;
    private Image imageComponent;
    public bool gmaebool = false;
    //空白建coin
    public GameObject imagespace1;

    public Image imagespace;
    public bool openimage2 = false;
    //結算
    public GameObject paneldown;
    public GameObject Blackdown;
    public GameObject Blackdown1;
    public GameObject Whitedown;
    public Text Settlementname;
    public Text Settlementname1;
    public Text Settlementnumber1;
    public Text Settlementnumber2;
    public Text qua;
    public Text qua1;
    public TMP_Text Settlementnumber3;
    public GameObject Exitbutton;
    //判定圖
    public GameObject opencoin;
    public GameObject opencoin1;
    public bool  hold1= false;
    public bool hold2= false;
    public bool hold3= false;
    private bool isSwitchingImages = false;
    private bool isSwitchingImages1 = true;
    public GameObject Space1;

    void Start()
    {
        imageComponent = CGGame.GetComponent<Image>();
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
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        Debug.Log("协程开始");

        // 暂停协程1秒
        yield return new WaitForSeconds(5);

        spicel2.SetActive(true);
        spicetext2.text = "你..你是什麼東西";
        Debug.Log("展示CG2");
        yield return new WaitForSeconds(2);
        spicel2.SetActive(false);
        spicel1.SetActive(true);
        spicetext1.text ="哎呀，你醒啦少年，我沒想到你醒這麼快";
        yield return new WaitForSeconds(2);
        spicel1.SetActive(false);
        imageComponent.sprite = CG2;
        yield return new WaitForSeconds(0.5f);
        imageComponent.sprite = CG1;
        yield return new WaitForSeconds(0.5f);
        imageComponent.sprite = CG2;
        yield return new WaitForSeconds(0.5f);
        imageComponent.sprite = CG1;
        yield return new WaitForSeconds(0.5f);
        imageComponent.sprite = CG2;
        yield return new WaitForSeconds(0.5f);
        imageComponent.sprite = CG3;
        spicel1.SetActive(true);
        spicetext1.text = " 噗咕";
        yield return new WaitForSeconds(1f);
        imageComponent.sprite = CG4;
        spicetext1.text = "今天不太舒服，放你一馬";
        yield return new WaitForSeconds(1f);
        spicel1.SetActive(false);
        quimage1.SetActive(true);
        
        opengame1 = true;
        while (!協成開始)
        {
            yield return null; // 暫停到下一偵
        }
        
        imageComponent.sprite = CG6;
        spicel2.SetActive(true);
        spicetext2.text = "別想逃";
        yield return new WaitForSeconds(1f); 
        spicel2.SetActive(false);
        spicel1.SetActive(true);
        spicetext1.text = "?";
        yield return new WaitForSeconds(1f);
       imageComponent.sprite = CG7;
        spicetext1.text = "疑..疑!";
        yield return new WaitForSeconds(1f);
        spicel1.SetActive(false);
        quimage2.SetActive(true);
        opengame1 = false;
        opengame2 = true;
        hold2 = true;
        while (health <= 50)
        {
            yield return null; // 暫停到下一偵
            
        }
        yield return new WaitForSeconds(1f);
        hold2 = false;
        opengame2 = false;
        quimage2.SetActive(false);
        Debug.Log("準備開始遊戲");
        yield return new WaitForSeconds(1f);
        imageComponent.sprite = CG11;
        spicel1.SetActive(true);
        spicetext1.text = "你沒有招了嗎";
        yield return new WaitForSeconds(1f);
        spicel1.SetActive(false);
        spicel2.SetActive(true);
        spicetext2.text = "少瞧不起人";
        yield return new WaitForSeconds(1f);
        quimage3.SetActive(true);
        spicel2.SetActive(false);
        opengame3 = true;
        while (gmaebool)
        {
            yield return null; // 暫停到下一偵
        }
        yield return new WaitForSeconds(3f);
        spicel2.SetActive(true);
        spicetext2.text = "胸部好軟";
        yield return new WaitForSeconds(1f);
        spicel2.SetActive(false);
        Debug.Log("遊戲再次開始");
        quimage2.SetActive(true);
        opengame2 = true;
        openimage2 = true;
        hold3 = true;
        while (health <= 100)
        {
            yield return null; // 暫停到下一偵
           // Debug.Log("測試遊戲");
        }
        hold3 = false;
        opengame2 = false;
        quimage2.SetActive(false);
        yield return new WaitForSeconds(1f);  
        openimage2 = false;
        opengame4 = true;
        quimage4.SetActive(true);

        while (opengame4)
        {
            yield return null; 
        }
        Space1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Space1.SetActive(false);
        hold1 = true;
        imagespace1.SetActive(true);
        while (coinbutton < 100)
        {
            yield return null; // 暫停到下一偵
           // Debug.Log("測試遊戲");
        }
        hold1 = false;
        imageComponent.sprite = CG23;
        
        yield return new WaitForSeconds(1f);
        paneldown.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Settlementname.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Settlementnumber1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Settlementname1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Settlementnumber2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Blackdown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Whitedown.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        qua1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        // RandomMove.SetActive(true);
        // opengame = true;
        // 暂停协程到下一帧
        yield return null;
        
        Debug.Log("下一帧继续");
        Exitbutton.SetActive(true);
        Debug.Log("条件满足，协程结束");
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
         
            if (opengame == true)
            {
                if (!判定上下左右1Called)
                {
                    判定上下左右1();
                }
                到計時();
                UpdateHealthBar();
                HandleInputModeA();
                測試();
                //  imagespeed = GameObject.Find("做愛UICanvas").GetComponent<Imagespeed>();
            }

            if (opengame1 == true)
            {
                if (!判定上下左右1Called)
                {
                    判定上下左右3();
                }
                else
                {
                    判定上下左右2();
                }
                測試1();
            }
            if (opengame3 == true)
            {
                if (!判定上下左右1Called)
                {
                    判定上下左右4();
                }
                else
                {
                    判定上下左右2();
                }
                測試1();
            }
            if (opengame4 == true)
            {
                Debug.Log("四階段");
                if (!判定上下左右1Called)
                {
                    判定上下左右5();
                }
                else
                {
                    判定上下左右2();
                }
                測試1();
            }
            if (opengame2 == true)
            {
                if (!判定上下左右1Called)
                {
                    判定上下左右3();
                }
                else
                {
                    判定上下左右2();
                }
                UpdateHealthBar();
                HandleInputModeB();
                測試2();
            }
            if (Input.GetKeyDown(KeyCode.Space)&& imagespace1.activeSelf&& hold1) 
            {
                Debug.Log("空白測試");
                Updatespace();
                if (imageComponent.sprite != CG21 && imageComponent.sprite != CG22)
                {
                    imageComponent.sprite = CG21;
                }
                else if (imageComponent.sprite == CG21)
                {
                    imageComponent.sprite = CG22;
                }
                else if (imageComponent.sprite == CG22)
                {
                    imageComponent.sprite = CG21;
                }
            }
        }
    }
   void HandleInputModeB() 
    {
        bool directionCorrect1 = true;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            directionCorrect1 = CheckDirection(top);
           
            if (directionCorrect1)
            {
                判定上下左右2(); // 如果方向按对，则进行圆圈的判定
                CheckInput(top);
            }
            else
            {
                Debug.Log("測試1");
                ResetCombo();
              //  HandleBadSprite1();
                StartCoroutine(HideJudgementImage(判定圖3));
                CheckInput(top);

            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            directionCorrect1 = CheckDirection(bottom);

            if (directionCorrect1)
            {
                判定上下左右2(); // 如果方向按对，则进行圆圈的判定
                CheckInput(bottom);
            }
            else
            {
                Debug.Log("測試2");
                ResetCombo();
              //  HandleBadSprite1();
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput(bottom);

            }

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
    private void HandleBadSprite1()
    {
        判定圖3.sprite = badSprite;
        badSpriteCount++;

        if (badSpriteCount >= 5)
        {
            施主你早射.gameObject.SetActive(true);
            TogglePause();
        }
        else
        {
            StartCoroutine(HideJudgementImage(判定圖3));
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
       // MoveRandomMove();
        // 顯示下一張圖
        DisplayRandomImage();
    }
    
    bool CheckDirection(Sprite correctDirection)
    {
        return displayImage.sprite == correctDirection;
    }
    private void 判定上下左右2() 
    {
        Debug.Log(numbleValue2);

        if (numbleValue2 <= 1.07f && numbleValue2 >= 0.97f)
        {
            // Perfect 范围
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)&& quimage1)
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                判定圖3.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試5");
                opengame1 = false;
                quimage1.SetActive(false);
             //   quimage2.SetActive(false);
                協成開始 = true;
            }
            if ((Input.GetKey(KeyCode.UpArrow) && opengame3))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                判定圖3.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試5");
                opengame3 = false;
                quimage3.SetActive(false);
                //   quimage2.SetActive(false);
                協成開始 = true;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) && opengame4))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                判定圖3.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試5");
                opengame4 = false;
                quimage4.SetActive(false);
                //   quimage2.SetActive(false);
                協成開始 = true;
            }
        }
        else if (numbleValue2 <= 1.25f && numbleValue2 >= 0.75f)
        {
            // Nice 范围
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && quimage1)
            {
                // 按键为 Nice
                Debug.Log("Nice!");
                判定圖3.sprite = niceSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試6");
                opengame1 = false;
                quimage1.SetActive(false);
              //  quimage2.SetActive(false);
                協成開始 = true;
            }
            if ((Input.GetKey(KeyCode.UpArrow) && opengame3))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                判定圖3.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試5");
                opengame3 = false;
                quimage3.SetActive(false);
                //   quimage2.SetActive(false);
                協成開始 = true;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) && opengame4))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                判定圖3.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試5");
                opengame4 = false;
                quimage4.SetActive(false);
                //   quimage2.SetActive(false);
                協成開始 = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && quimage1)
            {
                Debug.Log("Bad!");
                判定圖3.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試7");
                opengame1 = false;
                quimage1.SetActive(false);
             //   quimage2.SetActive(false);
                協成開始 = true;
            }
            if ((Input.GetKey(KeyCode.UpArrow) && opengame3))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                判定圖3.sprite = prefectSprite;
                StartCoroutine(HideJudgementImage(判定圖3));
                Debug.Log("測試5");
                opengame3 = false;
                quimage3.SetActive(false);
                //   quimage2.SetActive(false);
                協成開始 = true;
            }
        }

    }
    private void 判定上下左右3()
    {

        判定上下左右1Called = true;
        if (numbleValue2 < 0.7499f && 判定上下左右1Called)
        {
            Debug.Log(numbleValue2);
            Debug.Log("Bad! (Out of Range)");
            ResetCombo();
            判定圖3.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖3));
            Debug.Log("測試8");
            opengame1 = false;
            quimage1.SetActive(false);

            // quimage2.SetActive(false);
            協成開始 = true;
        }
        if(numbleValue3 < 0.7499f && 判定上下左右1Called) 
        {
            ResetCombo();
            判定圖3.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖3));
            StartCoroutine(HideAndShowOpencoin());
            isSwitchingImages1 = false;
            numbleValue3 = 1.7f;
            Debug.Log("5");
        }
        if (numbleValue4 < 0.7499f && 判定上下左右1Called)
        {
            ResetCombo();
            判定圖3.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖3));
            StartCoroutine(HideAndShowOpencoin1());
            isSwitchingImages1 = false;
            numbleValue4 = 1.7f;
            Debug.Log("6");

        }
        判定上下左右1Called = false;
    }
    private void 判定上下左右4()
    {

        判定上下左右1Called = true;
        if (numbleValue5 < 0.7499f && 判定上下左右1Called)
        {
            Debug.Log(numbleValue2);
            Debug.Log("Bad! (Out of Range)");
            ResetCombo();
            判定圖3.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖3));
            
            opengame3 = false;
            quimage3.SetActive(false);
            // quimage2.SetActive(false);
            協成開始 = true;
        }
        
        判定上下左右1Called = false;
    }
    private void 判定上下左右5()
    {

        判定上下左右1Called = true;
        
        if (numbleValue6 < 0.7499f && 判定上下左右1Called)
        {
            Debug.Log(numbleValue6);
            Debug.Log("Bad! (Out of Range)");
            ResetCombo();
            判定圖3.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖3));
            opengame4 = false;
            quimage4.SetActive(false);

            // quimage2.SetActive(false);
            協成開始 = true;
        }
        判定上下左右1Called = false;
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
          //  MoveRandomMove();
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
        //   Bar.fillAmount = Mathf.Lerp(Bar.fillAmount, targetFillAmount, _lerpSpeed * Time.deltaTime);
        Bar.fillAmount = targetFillAmount;
       //  if(targetFillAmount==1 && Bar.fillAmount > 0.9) 
       //  {
       //      Bar.fillAmount = 1;
       //      結();
       // }

        // 測試數字
       數字 = Bar.fillAmount;
    }
     void Updatespace() 
    {
        Addcoin();
        float targetFillAmount = coinbutton / maxcoinbutton;
        imagespace.fillAmount = targetFillAmount;
    } 
    private void Addcoin()
    {
        coinbutton += 10;  
    }
    public void AddHealth()
    {
        health += 10;
    }
    public void niceHealth() 
    {
        health += 5;
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
     
            TogglePause();
            結算.SetActive(true);
        
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
   // void MoveRandomMove()
   // {
    //    float panelLeft = panelRect.localPosition.x - panelRect.rect.width / 2;
    //    float panelRight = panelRect.localPosition.x + panelRect.rect.width / 2;
    //    float panelBottom = panelRect.localPosition.y - panelRect.rect.height / 2;
    //    float panelTop = panelRect.localPosition.y + panelRect.rect.height / 2;

        // 生成随机位置
   //     float randomX = Random.Range(panelLeft, panelRight);
  //      float randomY = Random.Range(panelBottom, panelTop);

        // 限制在指定范围内
  //      float clampedX = Mathf.Clamp(randomX, panelLeft, panelRight);
   //     float clampedY = Mathf.Clamp(randomY, panelBottom, panelTop);

   //     RandomMove.transform.localPosition = new Vector3(clampedX, clampedY, RandomMove.transform.localPosition.z);
  //  }
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
    public void 測試1()
    {
        Shrink1();

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)&& opengame1)
            {
                quimage1.SetActive(false);
               協成開始 = true;
               numbleValue2 = 1.7f;
         
            }
            else
            {

                if (numbleValue2 >= 0.75)
                {
                    numbleValue2 -= 0.1f * Time.deltaTime * speed1;
                }
                else
                {
                  quimage1.SetActive(false);
                  numbleValue2 = 1.7f;
                }
            }
        if (opengame3) 
        {
            Shrink3();
            if (Input.GetKey(KeyCode.UpArrow) )
            {
                quimage3.SetActive(false);
                imageComponent.sprite = CG12;
                numbleValue5 = 1.7f;
                gmaebool = true;
            }
            else
            {
                if (numbleValue5 >= 0.75)
                {
                    numbleValue5 -= 0.1f * Time.deltaTime * speed1;
                
                }
                else
                {
                
                    quimage3.SetActive(false);
                    numbleValue5 = 1.7f;
                }
            }
        }
        if (opengame4)
        {
            Debug.Log("測試用2");
            Shrink4();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                quimage4.SetActive(false);
                numbleValue6 = 1.7f;
                gmaebool = true;
                imageComponent.sprite = CG20;
                opengame4 = false;
            }
            else
            {
                if (numbleValue6 >= 0.75)
                {
                    numbleValue6 -= 0.1f * Time.deltaTime * speed1;

                }
                else
                {

                   // quimage4.SetActive(false);
                    numbleValue6 = 1.7f;
                }
            }
        }
    }
    public void 測試2()
    {
        Shrink2();


        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            
            numbleValue2 = 1.7f;
        }
        else
        {

            if (numbleValue2 >= 0.75)
            {
                numbleValue2 -= 0.1f * Time.deltaTime * speed1;
            }
            else
            {
                numbleValue2 = 1.7f;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && openimage2 && opencoin.activeSelf&&hold3) 
        {
         //   imageComponent.sprite = CG15;
            numbleValue3 = 1.7f;
            AddHealth();
            isSwitchingImages1 = true;
            StartCoroutine(HideAndShowOpencoin());
            if (!isSwitchingImages1) // Check if the SwitchImages1 coroutine is already running
            {
                StartCoroutine(SwitchImages1());
                isSwitchingImages1 = true;
            }
            Debug.Log("1");
            
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)&& opencoin.activeSelf && hold2)
        {
          //  imageComponent.sprite = CG10;
            AddHealth();
            numbleValue3 = 1.7f;
            isSwitchingImages1 = true;
            StartCoroutine(HideAndShowOpencoin());
            if (!isSwitchingImages) // Check if the SwitchImages coroutine is already running
            {
                StartCoroutine(SwitchImages());
                isSwitchingImages = true;
            }
            Debug.Log("2");
        }
        else
        {
            if (opencoin.activeSelf)
            {
                if (numbleValue3 >= 0.75)
                {
                    numbleValue3 -= 0.1f * Time.deltaTime * speed1;
                }
                else
                {
                    numbleValue3 = 1.7f;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && openimage2 && opencoin1.activeSelf && hold3) 
        {
          //  imageComponent.sprite = CG14;
            AddHealth();
            numbleValue4 = 1.7f;
            isSwitchingImages1 = true;
            StartCoroutine(HideAndShowOpencoin1());
            if (!isSwitchingImages) // Check if the SwitchImages1 coroutine is already running
            {
                StartCoroutine(SwitchImages1());
                isSwitchingImages = true;
            }
            Debug.Log("3");

        }
        else if ( Input.GetKeyDown(KeyCode.DownArrow) && opencoin1.activeSelf && hold2)
        {
          //  imageComponent.sprite = CG9;
            AddHealth();
            numbleValue4 = 1.7f;
            isSwitchingImages1= true;
            StartCoroutine(HideAndShowOpencoin1());
            if (!isSwitchingImages) // Check if the SwitchImages coroutine is already running
            {
                StartCoroutine(SwitchImages());
                isSwitchingImages = true;
            }
            Debug.Log("4");
        }
        else
        {
            if (opencoin1.activeSelf)
            {
                if (numbleValue4 >= 0.75)
                {
                    numbleValue4 -= 0.1f * Time.deltaTime * speed1;
                }
                else
                {
                    numbleValue4 = 1.7f;
                }
            }
        }
    }
    IEnumerator HideAndShowOpencoin()
    {
        opencoin.SetActive(false);     
        yield return new WaitForSeconds(2); 
        opencoin1.SetActive(true);       
    }
    IEnumerator HideAndShowOpencoin1()
    {
        opencoin1.SetActive(false);      
        yield return new WaitForSeconds(2); 
        opencoin.SetActive(true);       
    }
    public void Shrink()
    {

        image2.localScale = new Vector3(numbleValue1, numbleValue1, 1f);
        Vector3 newScale2 = image2.localScale;

    }
    public void Shrink1()
    {

        image3.localScale = new Vector3(numbleValue2, numbleValue2, 1f);
        Vector3 newScale3 = image3.localScale;
        image4.localScale = new Vector3(numbleValue2, numbleValue2, 1f);
        Vector3 newScale4 = image4.localScale;
       

    }
    public void Shrink2()
    {

        image5.localScale = new Vector3(numbleValue3, numbleValue3, 1f);
        Vector3 newScale3 = image5.localScale;
        image6.localScale = new Vector3(numbleValue4, numbleValue4, 1f);
        Vector3 newScale4 = image6.localScale;


    }
    public void Shrink3()
    {

        image7.localScale = new Vector3(numbleValue5, numbleValue5, 1f);
        Vector3 newScale3 = image7.localScale;
        image8.localScale = new Vector3(numbleValue5, numbleValue5, 1f);
        Vector3 newScale4 = image8.localScale;

    }
    public void Shrink4()
    {
        Debug.Log("測試用1");
        image9.localScale = new Vector3(numbleValue6, numbleValue6, 1f);
        Vector3 newScale3 = image9.localScale;
        image10.localScale = new Vector3(numbleValue6, numbleValue6, 1f);
        Vector3 newScale4 = image10.localScale;

    }
    private IEnumerator SwitchImages()
    {
        while (hold2&& isSwitchingImages1)
        {
            // 设置为 CG15
            imageComponent.sprite = CG9;
            yield return new WaitForSeconds(0.5f); // 等待 0.5 秒
            Debug.Log("8");
            // 设置为 CG16
            imageComponent.sprite = CG10;
            yield return new WaitForSeconds(0.5f); // 等待 0.5 秒
        }
        isSwitchingImages = false;
    }
    private IEnumerator SwitchImages1()
    {
        while (hold3&&isSwitchingImages1)
        {
            // 设置为 CG15
            imageComponent.sprite = CG14;
            yield return new WaitForSeconds(0.5f); // 等待 0.5 秒
            Debug.Log("9");
            // 设置为 CG16 
            imageComponent.sprite = CG15;
            yield return new WaitForSeconds(0.5f); // 等待 0.5 秒
        }
        isSwitchingImages = false;
    }
}

