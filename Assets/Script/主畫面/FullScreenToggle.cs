using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreenToggle : MonoBehaviour
{
    public TMP_Dropdown screenDroDown;
    public Toggle windowTog;
    public GameObject mag;

    private void Awake()
    {
        screenDroDown.onValueChanged.AddListener((int index) =>
        {
            switch (index)
            {
                case 0:
                    Screen.SetResolution(1920, 1080, false);
                    break;
                case 1:
                    Screen.SetResolution(3840, 2160, false);
                    break;
                case 2:
                    Screen.SetResolution(2560, 1440, false);
                    break;
                case 3:
                    Screen.SetResolution(1280, 720, false);
                    break;
                case 4:
                    Screen.SetResolution(960, 540, false);
                    break;
                case 5:
                    Screen.SetResolution(1600, 900, false);
                    break;
            }
        });
        windowTog.onValueChanged.AddListener((bool isSelected) => 
        {
          if(isSelected) 
            {
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                mag.SetActive(true);
            }
            else 
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
                mag.SetActive(false);
            }
        
        });
    }
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void SetWindowSize()
    {
        // 設置遊戲窗口高矮

        Screen.SetResolution(960, 540, false);
    }
    public void SetWindowSize1()
    {
        // 設置遊戲窗口高矮

        Screen.SetResolution(1920, 1080, false);
    }
    public void SetWindowSize2()
    {
        // 設置遊戲窗口高矮

        Screen.SetResolution(2560, 1440, false);
    }
    public void SetWindowSize3()
    {
        // 設置遊戲窗口高矮

        Screen.SetResolution(1280, 720, false);
    }
    public void SetWindowSize4()
    {
        // 設置遊戲窗口高矮

        Screen.SetResolution(1600, 900, false);
    }
    public void SetWindowSize5()
    {
        // 設置遊戲窗口高矮

        Screen.SetResolution(3840, 2160, false);
    }
    // 切換全頻模式
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    // 設置為全頻窗口
    public void SetFullScreenWindow()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    // 設置唯獨占全頻模式
    public void SetExclusiveFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    // 設置為窗口模式
    public void SetWindowedMode()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    // 設置為最大化窗口
    public void SetMaximizedWindow()
    {
        Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
    }
}
