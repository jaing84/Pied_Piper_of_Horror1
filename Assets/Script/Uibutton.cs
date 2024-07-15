using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uibutton : MonoBehaviour
{
    public Button settingbutton;
    public GameObject pausepanle;
    public GameObject backpanle;
    public GameObject backpanle2;
    // Start is called before the first frame update
    private void Awake()
    {
        settingbutton.onClick.AddListener(TogglePausePanel);
    }
    private void TogglePausePanel()
    {
        if (pausepanle.activeInHierarchy) 
        {
           pausepanle.SetActive(false);
            Time.timeScale = 1;
        }
        else 
        {
            pausepanle.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("按鍵A沒問題");

            if (backpanle2.activeInHierarchy)
            {
                backpanle2.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                backpanle2.SetActive(true);
                Time.timeScale = 0;
            }


        }

    }
}

