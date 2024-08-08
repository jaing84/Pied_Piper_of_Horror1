using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState
{
    Start,PlayerTurn, Player1Turn, Player2Turn,EnemyTurn, Enemy1Turn,MoveTurn, Enemy2Turn,Won,Lost
}
public class Battlesystem : MonoBehaviour
{
    public BattleState state;
    public int speed = 1;
    //戰鬥平台
    public GameObject PlayerPrefab;
    public GameObject PlayerPrefab2;
    public GameObject PlayerPrefab3;
    public GameObject EmemyPrefab;  
    public GameObject EmemyPrefab2;
    public GameObject EmemyPrefab3;
    public GameObject Special;
    //定義變數
    private GameObject player;
    private GameObject player1;
    private GameObject player2;
    private GameObject enemy;
    private GameObject enemy1;
    private GameObject enemy2;
    //位子
    public RectTransform PlayerBattleStation; 
    public RectTransform PlayerBattleStation1;
    public RectTransform PlayerBattleStation2;
    public RectTransform EnemyBattleStation; 
    public RectTransform EnemyBattleStation1;
    public RectTransform EnemyBattleStation2;
    public Pokemon playerPokemon;
    public Pokemon playerPokemon1;
    public Pokemon playerPokemon2;
    public Pokemon enemyPokemon;
    private float actionThreshold = 300f;
    //行動條
    private float playerActionMeter = 0f;
    private float player1ActionMeter = 0f;
    private float player2ActionMeter = 0f;
    private float enemyActionMeter = 0f;
    //行動圖
    public Image p1image;
    public Image p2image;
    public Image p3image;
    public Image enimage;
    //優先圖
    public Image p11image;
    public Image p22image;
    public Image p33image;
    public Text 戰鬥開始1;
    public GameObject 戰鬥開始;
    public GameObject 對話;
    private bool isSettingUpBattle = true;
    //戰鬥面板
    public BattleHUD playerHUD;
    public BattleHUD player1HUD; 
    public BattleHUD player2HUD;
    public BattleHUD enemyHUD;
    // public BattleHUD enemy1HUD;
    // public BattleHUD enemy2HUD;
    //戰鬥指令
    public GameObject AttackIns1;
    public GameObject AttackIns2;
    public GameObject AttackIns3;
    //技能選項出現
    public GameObject Attackcha1;
    public GameObject Attackcha2;
    public GameObject Attackcha3;
    //Boss攻擊提示
    public GameObject Ant;
    public Text Ant1;
    //移動物體
    public float moveSpeed = 5f;
    //指定物體
    public GameObject Object12;
    public GameObject Object13;
    //技能特效
    public GameObject 治療;
    public GameObject 治療1;
    public GameObject 治療2;
    //戰鬥角色
    public GameObject 戰鬥1;
    public GameObject 戰鬥2;
    public GameObject 戰鬥3;
    //判定
    public bool 目標已記錄1 = false;
    public bool 目標已記錄2 = false;
    public PlayerValues playerValues;
    //文字變動
    public TMP_Text HP1;
    public TMP_Text SAM1;
    void Start()
    {
        state = BattleState.Start;
       StartCoroutine(SetupBattle());

    }

    // Update is called once per frame
    void Update()
    {
        if (!isSettingUpBattle)
        {
            UpdateActionBars();
        }

        if (Object12) 
        {
            if (Input.GetMouseButtonDown(1)) // 1 表示右鍵，0 表示左鍵，2 表示中鍵
            {
                // 隱藏物件
                Object12.SetActive(false);
            }
        }
        if (Object13)
        {
            if (Input.GetMouseButtonDown(1)) // 1 表示右鍵，0 表示左鍵，2 表示中鍵
            {
                // 隱藏物件
                Object13.SetActive(false);
            }
        }
    }
    private IEnumerator SetupBattle()
    {
      player =  Instantiate(PlayerPrefab, PlayerBattleStation);
      player1 = Instantiate(PlayerPrefab2, PlayerBattleStation1);
      player2 = Instantiate(PlayerPrefab3, PlayerBattleStation2);
        enemy =  Instantiate(EmemyPrefab, EnemyBattleStation);
        //  Instantiate(EmemyPrefab2, EnemyBattleStation1);
        // Instantiate(EmemyPrefab3, EnemyBattleStation2);
        player.GetComponent<Pokemon>();
        player1.GetComponent<Pokemon>(); 
        player2.GetComponent<Pokemon>();
        playerPokemon = player.GetComponent<Pokemon>();
        playerPokemon1 = player1.GetComponent<Pokemon>();
        playerPokemon2 = player2.GetComponent<Pokemon>();
        enemyPokemon = enemy.GetComponent<Pokemon>();
        playerHUD.SetHUD(playerPokemon);
        player1HUD.SetHUD(playerPokemon1);
        player2HUD.SetHUD(playerPokemon2);
        enemyHUD.SetHUD(enemyPokemon);
        對話.SetActive(true);
        yield return new WaitForSeconds(1f);
        對話.SetActive(false);
        戰鬥開始.SetActive(true);
        yield return new WaitForSeconds(1f);
        戰鬥開始.SetActive(false);
        isSettingUpBattle = false;

    }
    private void PlayerAction()
    {
        StartCoroutine(PlayerAction1WithDelay());
    }
    private IEnumerator PlayerAction1WithDelay()
    {
        p11image.gameObject.SetActive(false);
        p22image.gameObject.SetActive(true);
        p33image.gameObject.SetActive(true);
        AttackIns1.gameObject.SetActive(true);
        AttackIns2.gameObject.SetActive(false);
        AttackIns3.gameObject.SetActive(false);
        Debug.Log("玩家回合");
        戰鬥開始.SetActive(true);
        戰鬥開始1.text = "吉娜回合";
        yield return new WaitForSeconds(0.5f);
        戰鬥開始.SetActive(false);
    }
    private void PlayerAction1()
    {
        StartCoroutine(PlayerAction2WithDelay());
    }
    private IEnumerator PlayerAction2WithDelay()
    {
        p11image.gameObject.SetActive(true);
        p22image.gameObject.SetActive(false);
        p33image.gameObject.SetActive(true);
        Debug.Log("玩家1回合");
        AttackIns1.gameObject.SetActive(false);
        AttackIns2.gameObject.SetActive(true);
        AttackIns3.gameObject.SetActive(false);
        戰鬥開始.SetActive(true);
        戰鬥開始1.text = "奧菲莉亞回合";
        yield return new WaitForSeconds(0.5f);
        戰鬥開始.SetActive(false);
    }
    private void PlayerAction2()
    {
        StartCoroutine(PlayerAction3WithDelay());
    }
    private IEnumerator PlayerAction3WithDelay()
    {
        p11image.gameObject.SetActive(true);
        p33image.gameObject.SetActive(false);
        p22image.gameObject.SetActive(true);
        Debug.Log("玩家2回合");
        AttackIns1.gameObject.SetActive(false);
        AttackIns2.gameObject.SetActive(false);
        AttackIns3.gameObject.SetActive(true);
        戰鬥開始.SetActive(true);
        戰鬥開始1.text = "貝琳達回合";
        yield return new WaitForSeconds(0.5f);
        戰鬥開始.SetActive(false);
    }

    private void EnemyAction()
    {
        StartCoroutine(EnemyTurn());
        p11image.gameObject.SetActive(true);
        p22image.gameObject.SetActive(true);
        p33image.gameObject.SetActive(true);
        Debug.Log("敵人回合");
      
    }

    public void OnAttackButton()
    {
        
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        
        StartCoroutine(PlayerAtteck(playerPokemon));
    }
    public void OnattackButton1() 
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(PlayerAtteck(playerPokemon1));
    }
    public void OnattackButton2()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(PlayerAtteck(playerPokemon2));
    }
    public void 防禦() 
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(PlayerDef(playerPokemon));
    }
    public void 防禦1()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(PlayerDef(playerPokemon1));
    }
    public void 防禦2()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(PlayerDef(playerPokemon2));
    }
    public void 群蛇之刺() 
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(Playerpuncture());
    }
    public void 誓死捍衛()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        Debug.Log("誓死捍衛");
        StartCoroutine(PlayerDef1());
    }
    public void 迅猛突進() 
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        Debug.Log("迅猛突進");
        StartCoroutine(PlayerAtteck1(playerPokemon1));

    }
    public void 永恆像真() 
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        Debug.Log("技能測試");
        StartCoroutine(Forever(playerPokemon2, playerPokemon, 0.3f));
    }
    public void 永恆像真1()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        Debug.Log("技能測試");
        StartCoroutine(Forever(playerPokemon2, playerPokemon1, 0.3f));
    }
    public void 永恆像真2()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        Debug.Log("技能測試");
        StartCoroutine(Forever(playerPokemon2, playerPokemon2, 0.3f));
    }

    public void 黑暗降臨() 
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
            return;
        StartCoroutine(Dark());
    }
 

    private IEnumerator Dark() 
    {
        bool isDefeated = enemyPokemon.TakeDamage(playerPokemon1.攻擊, enemyPokemon.防禦);
        playerPokemon.狂氣值(playerPokemon1.精神);
        playerPokemon1.狂氣值(playerPokemon1.精神);
        playerPokemon2.狂氣值(playerPokemon1.精神);
        更新面板();
        if (isDefeated)
        {
            state = BattleState.Won;
            EndBattle();
        }
        //檢查敵人是否擊敗1
        else
        {
            state = BattleState.MoveTurn;

        }
        // 等待一段時間後，將物件A移回原始位置
        //  MoveToTargetObject(attacker.transform, originalPosition);
        //進入下一個回合
        if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true)
        {
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
    }
    private IEnumerator Playerpuncture() 
    {
        int maxComboCount = 13;
        int currentComboCount = 0;
        float comboChance = 0.8f;
        Debug.Log("穿刺攻擊");
        bool canCombo = true;
        bool isDefeated = false;
        while (currentComboCount < maxComboCount)
        {
            yield return new WaitForSeconds(0.5f);
            if (canCombo)
            {
                isDefeated = enemyPokemon.Takepuncture(playerPokemon2.攻擊);
                currentComboCount++;
                Ant.SetActive(true);
                Ant1.text = (currentComboCount + "下");
                更新面板();
                Debug.Log("Combo! Count: " + currentComboCount);
            }
            else
            {
                Debug.Log("Combo Failed!");
                Ant.SetActive(false);
                break; 
            }
            canCombo = CanCombo(); 

        }
        if (currentComboCount >= maxComboCount)
        {
            Debug.Log("Max Combo Reached!");
            Ant.SetActive(false);
            currentComboCount = 0;
            state = BattleState.MoveTurn;
            yield break;
        }

        if (isDefeated)
        {
            state = BattleState.Won;
            EndBattle();
        }
        //檢查敵人是否擊敗1
        else
        {
            state = BattleState.MoveTurn;

        }
        bool CanCombo()
        {
            
            float randomValue = Random.value;
            return randomValue <= comboChance;
        }
        yield return new WaitForSeconds(0f);
        if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true)
        {
           
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
    }
    private IEnumerator PlayerDef(Pokemon def) 
    {
        def.Defense(def.防禦);
        Debug.Log(def.怪物名 +def.防禦 + "乘2成功");
        if (def == playerPokemon && state == BattleState.PlayerTurn)
        {
            state = BattleState.MoveTurn;
            yield return new WaitUntil(() => state == BattleState.PlayerTurn);
            Debug.Log(def.怪物名 + "防禦狀態失效");
            def.CancelDefense();
        }
        else if (def == playerPokemon1 && state == BattleState.Player1Turn)
        {
            state = BattleState.MoveTurn;
            yield return new WaitUntil(() => state == BattleState.Player1Turn);
            Debug.Log(def.怪物名 + "防禦狀態失效");
            def.CancelDefense();
        }
        else if (def == playerPokemon2 && state == BattleState.Player2Turn)
        {
            state = BattleState.MoveTurn;
            yield return new WaitUntil(() => state == BattleState.Player2Turn);
            Debug.Log(def.怪物名 + "防禦狀態失效");
            def.CancelDefense();
        }
        Debug.Log("測試1");  
    }
    private IEnumerator PlayerDef1()
    {
        playerPokemon1.Defense1(playerPokemon1.防禦); 
        playerPokemon2.Defense1(playerPokemon2.防禦);
        playerPokemon.Defense1(playerPokemon.防禦);
        Debug.Log(playerPokemon.怪物名 + playerPokemon.防禦 + "乘1.2成功");
        AttackIns1.gameObject.SetActive(false);
        state = BattleState.MoveTurn;
        yield return new WaitUntil(() => state == BattleState.PlayerTurn);
        playerPokemon1.CancelDefense1();
        Debug.Log("測試1");
    }
    private void ResetSpeed()
    {
        if (state == BattleState.PlayerTurn)
        {
            playerPokemon.速度 = playerPokemon.初始速度值;
        }
        else if (state == BattleState.Player1Turn)
        {
            playerPokemon1.速度 = playerPokemon1.初始速度值;
        }
        else
        {
            playerPokemon2.速度 = playerPokemon2.初始速度值;
        }
    }
    private IEnumerator Forever(Pokemon 使用者, Pokemon 目標, float 速度減益率) 
    {

        if (目標.目前血量 <= 0)
        {
            yield break;
        }

        if (使用者 != 目標 && 目標已記錄1|| 目標已記錄2)
        {
            if (目標已記錄1)
            {
                playerPokemon.forever(使用者.速度, 速度減益率);
                使用者.速度 = (int)(使用者.速度 * (1 - 速度減益率));
            }
            else if(目標已記錄2)
            {
                playerPokemon1.forever(使用者.速度, 速度減益率);
                使用者.速度 = (int)(使用者.速度 * (1 - 速度減益率));
            }
        }
        else if (使用者 != 目標 )
        {
            目標.forever(使用者.速度, 速度減益率);
            目標.速度 = (int)(目標.速度 * (1 - 速度減益率));
            使用者.速度 = (int)(使用者.速度 * (1 - 速度減益率));
            if(目標= playerPokemon) 
            {
                目標已記錄1 = true; 
            }
            else if(目標 = playerPokemon1)
            {
                目標已記錄2 = true;
            }
            else 
            {
                Debug.Log("目標對角色有BUG");
            }
        }
        else
        {
            使用者.forever(使用者.速度, 速度減益率);
            使用者.速度 = (int)(使用者.速度 * (1 - 速度減益率));
        }
        

        Debug.Log("測試");

        Object12.SetActive(false);
        更新面板();
        if (目標 == playerPokemon) 
        {
           治療.SetActive(true);
           yield return new WaitForSeconds(1f);
            治療.SetActive(false);
        }
        else if (目標 == playerPokemon1) 
        {
            治療1.SetActive(true);
            yield return new WaitForSeconds(1f);
            治療1.SetActive(false);
        }
        else 
        {
            治療2.SetActive(true);
            yield return new WaitForSeconds(1f);
            治療2.SetActive(false);
        }

           if (Attackcha1 || Attackcha2 || Attackcha3 == true)
          {
               Attackcha1.gameObject.SetActive(false);
               Attackcha2.gameObject.SetActive(false);
               Attackcha3.gameObject.SetActive(false);
           }
           if (AttackIns1 || AttackIns2 || AttackIns3 == true)
           {
                AttackIns1.gameObject.SetActive(false);
               AttackIns2.gameObject.SetActive(false);
               AttackIns3.gameObject.SetActive(false);
          }
        state = BattleState.MoveTurn;
      //  yield return new WaitUntil(() => state == BattleState.Player2Turn);
        BattleState previousState = state;
        while (true)
        {
            yield return new WaitUntil(() => state != previousState); // 等待状态变更
            previousState = state; // 更新 previousState
            Debug.Log("測試循環");
            switch (state)
            {
                case BattleState.PlayerTurn:
                    ResetSpeed();
                    目標已記錄1 = false;
                    break;
                case BattleState.Player1Turn:
                    ResetSpeed();
                    目標已記錄2 = false;
                    break;
                case BattleState.Player2Turn:
                    ResetSpeed();
                    break;
            }
            if (!目標已記錄1 && !目標已記錄2)
            {
                break; // 当目標已記錄1和目標已記錄2都为false时跳出循环
            }
        }
    }
    private void 更新面板()
    {
        HP1.text = ("HP:  "+ enemyPokemon.目前血量);
        SAM1.text = ("SAM:  " + enemyPokemon.目前狂氣值);
        enemyHUD.Setup(enemyPokemon.目前血量);
        playerHUD.SetHUD(playerPokemon);
        player1HUD.SetHUD(playerPokemon1);
        player2HUD.SetHUD(playerPokemon2);
        enemyHUD.SetHUD(enemyPokemon);
    }
    private IEnumerator PlayerAtteck(Pokemon attacker) 
    {
       
        Debug.Log("協成啟動成功");
        bool isDefeated = enemyPokemon.TakeDamage(attacker.攻擊, enemyPokemon.防禦);
        //對敵人造成傷害
        更新面板();
        // 保存玩家角色原始位置



        // 玩家移動到敵人
        // 確認攻擊者是哪個玩家角色，並將其移動到敵人位置
        if (attacker == playerPokemon && player != null)
        {
            AttackIns1.gameObject.SetActive(false);
            while (PlayerBattleStation.anchoredPosition.x <= 25)
            {
                PlayerBattleStation.anchoredPosition += new Vector2(playerPokemon2.速度 * 2 * Time.deltaTime * 10f * 3f, playerPokemon2.速度 * 2 * Time.deltaTime * 10f * 3f);
                Debug.Log("正在移動");
                yield return new WaitForSeconds(0.01f);
                Debug.Log("正在移動1");
            }
            Special.SetActive(true);
            yield return new WaitForSeconds(1f);
            Special.SetActive(false);
            PlayerBattleStation.anchoredPosition = new Vector2(-108, -241);

        }
        else if (attacker == playerPokemon1 && player1 != null)
        {
            AttackIns2.gameObject.SetActive(false);
            while (PlayerBattleStation1.anchoredPosition.x <= 15)
            {
                PlayerBattleStation1.anchoredPosition += new Vector2(playerPokemon1.速度 * 2 * Time.deltaTime * 30f*10f, playerPokemon1.速度 * 2 * Time.deltaTime * 7f * 10f);
                Debug.Log("正在移動");
                yield return new WaitForSeconds(0.01f);
                Debug.Log("正在移動1");
            }
            Special.SetActive(true);
            yield return new WaitForSeconds(1f);
            Special.SetActive(false);
            PlayerBattleStation1.anchoredPosition = new Vector2(-679, -141);
        }
        else if (attacker == playerPokemon2 && player2 != null)
        {
            AttackIns3.gameObject.SetActive(false);
            while (PlayerBattleStation2.anchoredPosition.x <= 60) 
            {
                PlayerBattleStation2.anchoredPosition += new Vector2(playerPokemon.速度 * 2 * Time.deltaTime * 20f * 5f, playerPokemon.速度 * 2 * Time.deltaTime * 7f * 5f);
                Debug.Log("正在移動");
                yield return new WaitForSeconds(0.01f);
                Debug.Log("正在移動1");
            }
            Special.SetActive(true);
            yield return new WaitForSeconds(1f);
            Special.SetActive(false);
            PlayerBattleStation2.anchoredPosition = new Vector2(-439, -171);
        }

        // 等待一段時間，模擬攻擊動作
        yield return new WaitForSeconds(0.5f);

        // 將玩家角色移回原始位置

        //攻擊傷害行動

        Debug.Log("攻擊傷害成功");
        yield return new WaitForSeconds(0f);
        if (isDefeated) 
        {
          state = BattleState.Won;
            EndBattle();
        }
        //檢查敵人是否擊敗1
        else
        {
            state = BattleState.MoveTurn;
            
        }
        // 等待一段時間後，將物件A移回原始位置
      //  MoveToTargetObject(attacker.transform, originalPosition);
        //進入下一個回合
        if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true) 
        {
            Debug.Log("2");
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
    }
    private IEnumerator PlayerAtteck1(Pokemon playerPokemon1)
    {

        Debug.Log("協成啟動成功");
        bool isDefeated = enemyPokemon.TakeDamage(playerPokemon1.攻擊, enemyPokemon.防禦);
        //對敵人造成傷害
        更新面板();
        // 保存玩家角色原始位置



        // 玩家移動到敵人
        // 確認攻擊者是哪個玩家角色，並將其移動到敵人位置


        AttackIns1.gameObject.SetActive(false);
        while (PlayerBattleStation.anchoredPosition.x <= 25)
        {
            PlayerBattleStation.anchoredPosition += new Vector2(playerPokemon2.速度 * 2 * Time.deltaTime * 10f * 3f, playerPokemon2.速度 * 2 * Time.deltaTime * 10f * 3f);
            Debug.Log("正在移動");
            yield return new WaitForSeconds(0.01f);
            Debug.Log("正在移動1");
        }
        Special.SetActive(true);
        yield return new WaitForSeconds(1f);
        Special.SetActive(false);
        PlayerBattleStation.anchoredPosition = new Vector2(-108, -241);




        // 等待一段時間，模擬攻擊動作
        yield return new WaitForSeconds(0.5f);

        // 將玩家角色移回原始位置

        //攻擊傷害行動

        Debug.Log("攻擊傷害成功");
        yield return new WaitForSeconds(0f);
        if (isDefeated)
        {
            state = BattleState.Won;
            EndBattle();
        }
        //檢查敵人是否擊敗1
        else
        {
            state = BattleState.MoveTurn;

        }
        // 等待一段時間後，將物件A移回原始位置
        //  MoveToTargetObject(attacker.transform, originalPosition);
        //進入下一個回合
        if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true)
        {
            Debug.Log("2");
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
    }

    private void EndBattle() 
    {
      if(state == BattleState.Won) 
        {
            Debug.Log("勝利");
         //   playerValues.怪物名.text = playerPokemon2.怪物名.ToString();
            playerValues.攻擊.text = playerPokemon2.GetComponent<Pokemon>().攻擊.ToString();
            playerValues.防禦.text = playerPokemon2.GetComponent<Pokemon>().防禦.ToString();
            playerValues.速度 = playerPokemon2.GetComponent<Pokemon>().速度;
            playerValues.精神 = playerPokemon2.GetComponent<Pokemon>().精神;
            playerValues.爆擊率.text = playerPokemon2.GetComponent<Pokemon>().爆擊率.ToString()+"%";
            playerValues.爆擊傷害.text = playerPokemon2.GetComponent<Pokemon>().爆擊傷害.ToString()+"%";
            playerValues.最大血量.text = playerPokemon2.GetComponent<Pokemon>().目前血量.ToString() + "/"+ playerPokemon2.GetComponent<Pokemon>().最大血量.ToString();
            playerValues.目前血量 = playerPokemon2.GetComponent<Pokemon>().目前血量;
            playerValues.最大狂氣值.text = playerPokemon2.GetComponent<Pokemon>().目前狂氣值.ToString() +"/"+ playerPokemon2.GetComponent<Pokemon>().最大狂氣值.ToString();
            playerValues.目前狂氣值 = playerPokemon2.GetComponent<Pokemon>().目前狂氣值;

            Teleport teleporter = GameObject.FindObjectOfType<Teleport>();
            if (teleporter != null)
            {
                teleporter.TeleportToScene();
            }

        }
      else if (state == BattleState.Lost) 
        {
            Debug.Log("失敗");
            戰鬥開始.SetActive(true);
            戰鬥開始1.text = "失       敗";

        }
    }
    private IEnumerator EnemyTurn() 
    {
        bool foundValidTarget = false;
        Pokemon targetPokemon = null;
        戰鬥開始.SetActive(true);
        戰鬥開始1.text = "敵人回合";
        yield return new WaitForSeconds(0.5f);
        戰鬥開始.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        while (!foundValidTarget)
        {
            int randomIndex = Random.Range(0, 3); //隨機數
            switch (randomIndex)
            {
                case 0:
                    targetPokemon = playerPokemon;
                    break;
                case 1:
                    targetPokemon = playerPokemon1;
                    break;
                case 2:
                    targetPokemon = playerPokemon2;
                    break;
                default:
                    Debug.LogError("Invalid random index: " + randomIndex);
                    break;

            }
            if (targetPokemon != null && targetPokemon.目前血量 > 0)
            {
                foundValidTarget = true;
            }
        }
        if (targetPokemon != null)
        {
            bool isDefeated = targetPokemon.TakeDamage(enemyPokemon.攻擊, targetPokemon.防禦);
            int 攻擊力 = enemyPokemon.攻擊;
            int 防禦力 = targetPokemon.新防禦;

            Ant.SetActive(true);
            int 傷害 = 攻擊力 - 防禦力;
            Ant1.text = ("對"+targetPokemon.怪物名+"造成"+傷害+"傷害");
            yield return new WaitForSeconds(1f);
            Ant.SetActive(false);

            更新面板();
            if (isDefeated)
            {
                // state = BattleState.Lost;
                // EndBattle();
                state = BattleState.MoveTurn;
            }
            else
            {
                state = BattleState.MoveTurn;
            }
        }
    }
    public void 恐怖操線()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
        {
            return;
        }
        if (p1image.rectTransform.anchoredPosition.x > 0)
        {
            // 如果不低於 0，則進行修改
            p1image.rectTransform.anchoredPosition -= new Vector2(300, 0f);
        }
        else
        {
            // 如果低於 0，將其設置為 0
            p1image.rectTransform.anchoredPosition = new Vector2(-275f, 0);
        }
        Object13.SetActive(false) ;
        state = BattleState.MoveTurn;
        if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true)
        {
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
    }
    public void 恐怖操線1()
    {
        if (state == BattleState.Start || state == BattleState.EnemyTurn || state == BattleState.Enemy1Turn || state == BattleState.MoveTurn || state == BattleState.Enemy2Turn || state == BattleState.Won || state == BattleState.Lost)
        {
            return;
        }
        if (p3image.rectTransform.anchoredPosition.x > 0)
        {
            // 如果不低於 0，則進行修改
            p3image.rectTransform.anchoredPosition -= new Vector2(300, 0f);
        }
        else
        {
            // 如果低於 0，將其設置為 0
            p3image.rectTransform.anchoredPosition = new Vector2(-275f, 0);
        }
        Object13.SetActive(false);
        state = BattleState.MoveTurn;
        if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true)
        {
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
    }
    void UpdateActionBars() 
    {
        if (state == BattleState.Start || state == BattleState. MoveTurn )
        {
            bool playerAlive = playerPokemon.目前血量 > 0;
            bool player1Alive = playerPokemon1.目前血量 > 0;
            bool player2Alive = playerPokemon2.目前血量 > 0;

            if (!playerAlive)
            {
                playerActionMeter = 0f;
            }
            if (!player1Alive)
            {
                player1ActionMeter = 0f;
            }
            if (!player2Alive)
            {
                player2ActionMeter = 0f;
            }
            if (!playerAlive && !player1Alive && !player2Alive)
            {
                state = BattleState.Lost;
                EndBattle();
                return;
            }

 
            // 增加行動條
            playerActionMeter += playerPokemon.速度 * Time.deltaTime * speed;
            player1ActionMeter += playerPokemon1.速度 * Time.deltaTime * speed;
            player2ActionMeter += playerPokemon2.速度 * Time.deltaTime * speed;
            enemyActionMeter += enemyPokemon.速度 * Time.deltaTime * speed;
            p1image.rectTransform.anchoredPosition -= new Vector2(playerPokemon.速度 * 2 * Time.deltaTime * speed, 0f);
            p2image.rectTransform.anchoredPosition -= new Vector2(playerPokemon1.速度 * 2 * Time.deltaTime * speed, 0f);
            p3image.rectTransform.anchoredPosition -= new Vector2(playerPokemon2.速度 * 2 * Time.deltaTime * speed, 0f);
            enimage.rectTransform.anchoredPosition -= new Vector2(enemyPokemon.速度 * 2 * Time.deltaTime * speed, 0f);
            // 如果行動條達到閾值，執行相應角色的行動
            if (playerActionMeter >= actionThreshold)
            {
                state = BattleState.PlayerTurn;
                PlayerAction();
                playerActionMeter = 0f; // 重置行動條
                p1image.rectTransform.anchoredPosition = new Vector2(300, 0);
            }
            if (player1ActionMeter >= actionThreshold)
            {
                state = BattleState.Player1Turn;
                PlayerAction1();
                player1ActionMeter = 0f; // 重置行動條
                p2image.rectTransform.anchoredPosition = new Vector2(300, 0);
            }
            if (player2ActionMeter >= actionThreshold)
            {
                state = BattleState.Player2Turn;
                PlayerAction2();
                player2ActionMeter = 0f; // 重置行動條
                p3image.rectTransform.anchoredPosition = new Vector2(300, 0);
            }

            if (enemyActionMeter >= actionThreshold)
            {
                state = BattleState.EnemyTurn;
                EnemyAction();
                enemyActionMeter = 0f; // 重置行動條
                enimage.rectTransform.anchoredPosition = new Vector2(300, 0);
            }
        }

    }
    public void 指定對象顯示() 
    {
        Object12.SetActive(true);
    }
    public void 指定對象顯示1()
    {
        Object13.SetActive(true);
    }
    public void 指定對象隱藏()
    {
        Object12.SetActive(false);
        state = BattleState.MoveTurn;
       if (Attackcha1 || Attackcha2 || Attackcha3 == true)
        {
            Attackcha1.gameObject.SetActive(false);
            Attackcha2.gameObject.SetActive(false);
            Attackcha3.gameObject.SetActive(false);
        }
        if (AttackIns1 || AttackIns2 || AttackIns3 == true)
        {
            AttackIns1.gameObject.SetActive(false);
            AttackIns2.gameObject.SetActive(false);
            AttackIns3.gameObject.SetActive(false);
        }
    }
}

