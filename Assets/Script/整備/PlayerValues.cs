using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{
    public Text 怪物名;
    public Text 攻擊;
    public Text 防禦;
    public int 速度;
    public int 精神;
    public Text 最大血量;
    public int 目前血量;
    public Text 最大狂氣值;
    public int 目前狂氣值;
    public Text 爆擊率;
    public Text 爆擊傷害;
    public int 裝備速度;
    public int 裝備精神;
    public Battlesystem battlesystem;
    public MagicSquareController magicSquareController;
    public Text 合體速度Text;
    public Text 合體精神Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int 合體速度 = 速度 + 裝備速度;
        int 合體精神 = 精神 + 裝備精神;

        合體速度Text.text = 合體速度.ToString();
        合體精神Text.text = 合體精神.ToString();
    }
}
