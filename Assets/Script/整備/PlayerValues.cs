using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{
    public Text �Ǫ��W;
    public Text ����;
    public Text ���m;
    public int �t��;
    public int �믫;
    public Text �̤j��q;
    public int �ثe��q;
    public Text �̤j�g���;
    public int �ثe�g���;
    public Text �z���v;
    public Text �z���ˮ`;
    public int �˳Ƴt��;
    public int �˳ƺ믫;
    public Battlesystem battlesystem;
    public MagicSquareController magicSquareController;
    public Text �X��t��Text;
    public Text �X��믫Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int �X��t�� = �t�� + �˳Ƴt��;
        int �X��믫 = �믫 + �˳ƺ믫;

        �X��t��Text.text = �X��t��.ToString();
        �X��믫Text.text = �X��믫.ToString();
    }
}
