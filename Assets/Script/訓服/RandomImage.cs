using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class RandomImage : MonoBehaviour
{
   public Sprite[] images;
    public Sprite top;
    public Sprite bottom;
    public Sprite left;
    public Sprite right;
    public Image displayImage;
    public Image displayImage2;
    public Text scoreText;
    private int score = 0;
    public RectTransform image1;
    public RectTransform image2;
    public float bossscore = 0;
    public float leadscore = 0;
    public float maxleadscore = 400;
    public float maxbossscore = 550;
    public bool canUseSkill = true;
    public Text timerText;
    public float timeRemaining = 90f;
    public int keyPressCount = 0;
    public bool canUseCSkill = true;  //是否可以使用C技能
    public bool isCooldown = false;  //C技能是否在冷却中
    public bool isCooldown1 = false;
   // private float cSkillCooldownTime = 20f;
    public bool canUseCSkill2 = true;
    public float cooldownTime = 15f; //攻守抗衡
    public Image cooldownImage;//攻守抗衡
    public float cooldownTime2 = 20f; //聖人降臨
    public Image cooldownImage2;//聖人降臨
    public Image cooldownImage3; // 同調
    Imagerange imagerange;
    public int combo;
    public Text combotext;
    public Image 判定圖1;
    public Image 判定圖2;
    public Sprite prefectSprite;
    public Sprite niceSprite;
    public Sprite badSprite;
    public Sprite nullSprite;
    public Image 施主你早射;
    private enum InputMode { A, B }
    private InputMode currentInputMode = InputMode.A;
    private int initialScore = 0;


    void Start()
    {
        DisplayRandomImage();
        StartCoroutine(Countdown());
        imagerange = GameObject.Find("馴服UICanvas").GetComponent<Imagerange>();
        if (imagerange == null)
        {
            Debug.LogError("馴服UICanvas");
        }
        initialScore = score;
    }
    private void Update()
    {
        if(leadscore == 400) 
        {
            施主你早射.gameObject.SetActive(true);
        }
        else
        {
            施主你早射.gameObject.SetActive(false);
        }

        判定上下左右1();
        判定WSAD1();
        if (isCooldown) 
        {
            canUseCSkill = false;
        }
        else 
        {
            canUseCSkill = true;
            if (Input.GetKeyDown(KeyCode.C) && canUseCSkill)
            {
                if (currentInputMode == InputMode.A)
                {
                    currentInputMode = InputMode.B;
                    keyPressCount = 0; // 重置按键计数器
                    cooldownImage2.fillAmount = 0f;
                    UpdateSkillBars();
                    StartCoroutine(Skill2Cooldown());// 更新技能条
                    isCooldown = true;
                    
                }
                else
                {
                    currentInputMode = InputMode.A;

                }
            }
 
        }

        // 根据当前输入模式执行相应操作
        if (currentInputMode == InputMode.A)
        {
            // A 模式下的操作
            HandleInputModeA();
        }
        else if (currentInputMode == InputMode.B)
        {
            // B 模式下的操作
            HandleInputModeB();
        }
    


        if (Input.GetKeyDown(KeyCode.Z) && canUseSkill)
        {
            StartCoroutine(DelaySkillUsage());
            攻守抗衡();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (canUseCSkill2)
            {
                同調();
                cooldownImage3.fillAmount = 0f;
                canUseCSkill2 = false;   
            }  
        }

    }
    void HandleInputModeA()
    {
        bool directionCorrect = true; 
        bool directionCorrect2 = false;
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
                ResetCombo();
                判定圖2.sprite = badSprite;
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

                ResetCombo();
                判定圖2.sprite = badSprite;
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
 
                ResetCombo();
                判定圖2.sprite = badSprite;
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

                ResetCombo();
                判定圖2.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput(right);
            }

        }
  

            if (Input.GetKeyDown(KeyCode.W))
        {
            directionCorrect2 = CheckDirection1(top);
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput1(top);
            }
            else
            {

                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput1(top);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionCorrect2 = CheckDirection1(bottom);
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput1(bottom);
            }
            else
            {
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput1(bottom);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            directionCorrect2 = CheckDirection1(left);
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput1(left);
            }
            else
            {
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput1(left);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionCorrect2 = CheckDirection1(right);
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput1(right);
            }
            else
            {
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput1(right);
            }
        }

    }

    void HandleInputModeB()
    {
        bool directionCorrect = true;
        bool directionCorrect2 = false;
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            directionCorrect = CheckDirection(top);
            keyPressCount++;
            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput2(top);
  
            }
            else
            {
                ResetCombo();
                判定圖2.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput2(top);
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            directionCorrect = CheckDirection(bottom);
            keyPressCount++;
            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput2(bottom);
 
            }
            else
            {

                ResetCombo();
                判定圖2.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput2(bottom);

            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionCorrect = CheckDirection(left);
            keyPressCount++;
            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput2(left);

            }
            else
            {

                ResetCombo();
                判定圖2.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput2(left);
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionCorrect = CheckDirection(right);
            keyPressCount++;
            if (directionCorrect)
            {
                判定上下左右(); // 如果方向按对，则进行圆圈的判定
                CheckInput2(right);
            }
            else
            {

                ResetCombo();
                判定圖2.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖2));
                CheckInput2(right);
            }

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            directionCorrect2 = CheckDirection1(top);
            keyPressCount++;
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput3(top);
            }
            else
            {

                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput3(top);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionCorrect2 = CheckDirection1(bottom);
            keyPressCount++;
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput3(bottom);
            }
            else
            {
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput3(bottom);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            directionCorrect2 = CheckDirection1(left);
            keyPressCount++;
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput3(left);
            }
            else
            {
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput3(left);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionCorrect2 = CheckDirection1(right);
            keyPressCount++;
            if (directionCorrect2)
            {
                判定WSAD();
                CheckInput3(right);
            }
            else
            {
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
                CheckInput3(right);
            }
        }
        if (keyPressCount >= 5)
        {
            currentInputMode = InputMode.A;
        }

    }

    void StartSkillCooldown()
    {
        cooldownImage.fillAmount = 0f; 
        StartCoroutine(SkillCooldown());
    }
    private IEnumerator Skill2Cooldown()
    {
        isCooldown = true;
        float timer = 0f;
        while (timer < cooldownTime2)
        {
            timer += Time.deltaTime;
            float fillAmount = timer / cooldownTime2;
            cooldownImage2.fillAmount = fillAmount;
            yield return null; 
        }

        isCooldown = false;
        cooldownImage2.fillAmount = 1f;
    }

    private IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(20f); 
        isCooldown = false; 
        keyPressCount = 0; 
    }
    private void StartCooldown()
    {
        StartCoroutine(CooldownTimer());
    }
    private IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            Debug.Log("1");
            DisplayTime(timeRemaining);
            yield return new WaitForSeconds(1f); // 等待一秒鐘
            timeRemaining--; // 每過一秒 減1
        }

        
        Debug.Log("倒计时结束！");
    }
    void DisplayTime(float timeToDisplay)
    {
        // 更新UI
        timerText.text = Mathf.RoundToInt(timeToDisplay).ToString();
    }

    IEnumerator DelaySkillUsage()
    {
        canUseSkill = false;
        Debug.Log("測試一");
        
        yield return new WaitForSeconds(15);    
        canUseSkill = true;
        Debug.Log("測試二");
    }
    IEnumerator SkillCooldown()
    {
        float timer = 0f;
        isCooldown1 = true;
        while (timer < cooldownTime)
        {
            timer += Time.deltaTime;
            float fillAmount = timer / cooldownTime;
            cooldownImage.fillAmount = fillAmount;
            yield return null;

        }
        isCooldown1 = false;
        cooldownImage.fillAmount = 1f;
    }
    public void DisplayRandomImage()
    {
        
        int randomIndex = Random.Range(0, images.Length);

       
        Sprite randomImage = images[randomIndex];

        
        displayImage.sprite = randomImage;
    }
    public void DisplayRandomImage2()
    {

        int randomIndex = Random.Range(0, images.Length);


        Sprite randomImage = images[randomIndex];


        displayImage2.sprite = randomImage;
    }
    void CheckInput(Sprite correctSprite)
    {
        if (displayImage.sprite == correctSprite)
        {
            
            // 正確加分
            score++;
            scoreText.text = "Score: " + score.ToString();
            if (判定圖2.sprite == prefectSprite)
            {
                Debug.Log("觸發");
                bossscore += 5;
                leadscore += 5;
            }
            else if (判定圖2.sprite == niceSprite)
            {
                bossscore += 2;
                leadscore += 5;
            }
            else if (判定圖2.sprite == badSprite)
            {
                bossscore -= 5;
                leadscore += 10;
            }
            bossscore = Mathf.Max(bossscore, 0);
            bossscore = Mathf.Min(bossscore, maxbossscore);
            leadscore = Mathf.Min(leadscore, maxleadscore);
            UpdateSkillBars();
            Debug.Log("正確");
            
        }
        else
        {
            // 錯誤扣分
            score--;
            if (判定圖2.sprite == badSprite)
            {
                bossscore -= 5;
                leadscore += 10;
            }
            bossscore = Mathf.Max(bossscore, 0);
            leadscore = Mathf.Min(leadscore, maxleadscore);
            scoreText.text = "Score: " + score.ToString();
            UpdateSkillBars();
            Debug.Log("錯誤");
        }

        // 顯示下一張圖
        DisplayRandomImage();
    }
    void CheckInput2(Sprite correctSprite)
    {
        if (displayImage.sprite == correctSprite)
        {

            // 正確加分
            score++;
            scoreText.text = "Score: " + score.ToString();
            if (判定圖2.sprite == prefectSprite)
            {
                Debug.Log("觸發");
                bossscore += 5;
            }
            else if (判定圖2.sprite == niceSprite)
            {
                bossscore += 2;
            }
            else if (判定圖2.sprite == badSprite)
            {
                bossscore -= 5;
            }
            bossscore = Mathf.Max(bossscore, 0);
            bossscore = Mathf.Min(bossscore, maxbossscore);
            leadscore = Mathf.Min(leadscore, maxleadscore);
            UpdateSkillBars();
            Debug.Log("正確");

        }
        else
        {
            // 錯誤扣分
            score--;
            if (判定圖2.sprite == badSprite)
            {
                bossscore -= 5;
            }
            bossscore = Mathf.Max(bossscore, 0);
            leadscore = Mathf.Min(leadscore, maxleadscore);
            scoreText.text = "Score: " + score.ToString();
            UpdateSkillBars();
            Debug.Log("錯誤");
        }

        // 顯示下一張圖
        DisplayRandomImage();
    }
    bool CheckDirection(Sprite correctDirection)
    {
        if (displayImage.sprite == correctDirection)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
    void CheckInput1(Sprite correctSprite)
    {
        if (displayImage2.sprite == correctSprite)
        {
            // 正確加分
            score++;
            scoreText.text = "Score: " + score.ToString();
            if (判定圖1.sprite == prefectSprite)
            {
                Debug.Log("觸發");
                bossscore += 5;
                leadscore += 5;
            }
            else if (判定圖1.sprite == niceSprite)
            {
                bossscore += 2;
                leadscore += 5;
            }
            else if (判定圖1.sprite == badSprite)
            {
                bossscore -= 5;
                leadscore += 10;
            }
            leadscore = Mathf.Min(leadscore, maxleadscore);
            bossscore = Mathf.Min(bossscore, maxbossscore);
            bossscore = Mathf.Max(bossscore, 0);
            UpdateSkillBars();
        }
        else
        {
            // 錯誤扣分
            score--;
            scoreText.text = "Score: " + score.ToString();
           if (判定圖1.sprite == badSprite)
            {
                bossscore -= 5;
                leadscore += 10;
            }
            leadscore = Mathf.Min(leadscore, maxleadscore);
            bossscore = Mathf.Max(bossscore, 0);
            UpdateSkillBars();
        }

        // 顯示下一張圖
        DisplayRandomImage2();
    }
    void CheckInput3(Sprite correctSprite)
    {
        if (displayImage2.sprite == correctSprite)
        {
            // 正確加分
            score++;
            scoreText.text = "Score: " + score.ToString();
            if (判定圖1.sprite == prefectSprite)
            {
                Debug.Log("觸發");
                bossscore += 5;
            }
            else if (判定圖1.sprite == niceSprite)
            {
                bossscore += 2;
            }
            else if (判定圖1.sprite == badSprite)
            {
                bossscore -= 5;
            }
            leadscore = Mathf.Min(leadscore, maxleadscore);
            bossscore = Mathf.Min(bossscore, maxbossscore);
            bossscore = Mathf.Max(bossscore, 0);
            UpdateSkillBars();
        }
        else
        {
            // 錯誤扣分
            score--;
            scoreText.text = "Score: " + score.ToString();
            if (判定圖1.sprite == badSprite)
            {
                bossscore -= 5;
            }
            leadscore = Mathf.Min(leadscore, maxleadscore);
            bossscore = Mathf.Max(bossscore, 0);
            UpdateSkillBars();
        }

        // 顯示下一張圖
        DisplayRandomImage2();
    }
    bool CheckDirection1(Sprite correctDirection)
    {
        if (displayImage2.sprite == correctDirection)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void UpdateSkillBars() 
    {
        float newScaleX = leadscore / maxleadscore;
        Vector3 newScale = image1.localScale;
        newScale.x = newScaleX;
        image1.localScale = newScale;

        float newScale1X = bossscore / maxbossscore;
        Vector3 newScale1 = image2.localScale;
        newScale1.x = newScale1X;
        image2.localScale = newScale1;
    }

    private void 攻守抗衡()
    {
        float a = leadscore / maxleadscore;
        float b = bossscore / maxbossscore;

        // 重新計算分數
        bossscore = a * maxbossscore;
        leadscore = b * maxleadscore;
        StartSkillCooldown();
        // 更新技能條
        UpdateSkillBars();
    }
    private void 同調()
    {
        bossscore = leadscore;
        UpdateSkillBars();
    }
    private void 聖人降臨()
    {
        bossscore += 5;
        UpdateSkillBars();
    }

    private void 判定WSAD()
    {
        float numbleValue = imagerange.Numble;
        if (numbleValue <= 1.07f && numbleValue >= 0.97f)
        {
            // Perfect 范围
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                // 按键为 Perfect
                Debug.Log("Perfect!");
                IncrementCombo();
                判定圖1.sprite = prefectSprite; 
                StartCoroutine(HideJudgementImage(判定圖1)); 
            }
        }
        else if (numbleValue <= 1.1f && numbleValue >= 0.95f)
        {
            // Nice 范围
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                // 按键为 Nice
                Debug.Log("Nice!");
                IncrementCombo();
                判定圖1.sprite = niceSprite; // 更改图片为 Nice
                StartCoroutine(HideJudgementImage(判定圖1));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Bad!");
                ResetCombo();
                判定圖1.sprite = badSprite;
                StartCoroutine(HideJudgementImage(判定圖1));
            }
        }
       
    }
    private void 判定WSAD1() 
    {
        float numbleValue = imagerange.Numble;
        if (numbleValue < 0.9001f)
        {

            Debug.Log("Bad! (Out of Range)");
            ResetCombo();
            判定圖1.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖1));
            bossscore -= 5;
            leadscore += 10;
            leadscore = Mathf.Min(leadscore, maxleadscore);
            bossscore = Mathf.Min(bossscore, maxbossscore);
            bossscore = Mathf.Max(bossscore, 0);
            UpdateSkillBars();
        }

    }
    private void 判定上下左右()
    {
        float numbleValue1 = imagerange.Numble1;
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

            }
        }
        else if (numbleValue1 <= 1.1f && numbleValue1 >= 0.95f)
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
            }
        }
        
    }
    private void 判定上下左右1() 
    {
        float numbleValue1 = imagerange.Numble1;
        if (numbleValue1 < 0.9001f)
        {

            Debug.Log("Bad! (Out of Range)");
            ResetCombo();
            判定圖2.sprite = badSprite;
            StartCoroutine(HideJudgementImage(判定圖2));
            bossscore -= 5;
            leadscore += 10;
            leadscore = Mathf.Min(leadscore, maxleadscore);
            bossscore = Mathf.Min(bossscore, maxbossscore);
            bossscore = Mathf.Max(bossscore, 0);
            UpdateSkillBars();
        }

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
        // 重置遊戲狀態為初始值
        score = initialScore;
        leadscore = 0;
        bossscore = 0;
        // 其他需要重置的遊戲狀態...

        // 更新 UI 或其他元素
        scoreText.text = "Score: " + score.ToString();
        UpdateSkillBars();
    }
}
