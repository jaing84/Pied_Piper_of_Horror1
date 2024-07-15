using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject 主選單UI; // A場景的UI
    public GameObject 劇情UI; // B場景的UI
    public GameObject 戰鬥UI; // C場景的UI
    public GameObject 訓服UI;
    public GameObject 整備UI;
    public GameObject 次目錄UI;
    public GameObject 文字劇情;
    public GameObject 角色儲存;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 訂閱場景加載事件
        UpdateUI(); // 更新UI顯示
    }

    public void Update()
    {
        UpdateUI();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUI(); // 加載場景後更新UI顯示
    }

    private void UpdateUI()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        // 根據當前場景名稱顯示或隱藏對應的UI
        switch (sceneName)
        {
            case "H1":
                主選單UI.SetActive(true);
                劇情UI.SetActive(false);
                戰鬥UI.SetActive(false);
                訓服UI.SetActive(false);
                整備UI.SetActive(false);
                文字劇情.SetActive(false);
                break;
            case "H2":
                主選單UI.SetActive(false);
                劇情UI.SetActive(true);
                戰鬥UI.SetActive(false);
                訓服UI.SetActive(false);
                整備UI.SetActive(false);
                文字劇情.SetActive(true);
                break;
            case "H3":
                主選單UI.SetActive(false);
                劇情UI.SetActive(false);
                戰鬥UI.SetActive(true);
                訓服UI.SetActive(false);
                整備UI.SetActive(false);
                文字劇情.SetActive(false);
                角色儲存.SetActive(true);
                break;
            case "H4":
                主選單UI.SetActive(false);
                劇情UI.SetActive(false);
                戰鬥UI.SetActive(false);
                訓服UI.SetActive(true);
                整備UI.SetActive(false);
                文字劇情.SetActive(false);
                break;
            case "H5":
                主選單UI.SetActive(false);
                劇情UI.SetActive(false);
                戰鬥UI.SetActive(false);
                訓服UI.SetActive(false);
                整備UI.SetActive(true);
                文字劇情.SetActive(false);
                break;
            default:
                //  Debug.Log("Unknown scene name: " + sceneName);
                break;
        }

    }

}

