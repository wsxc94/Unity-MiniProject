﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    //시작버튼 클릭했을때
    public void OnStartButtonClick()
    {
        //SceneManager.LoadScene("GameScene");
        SceneMgr.Instance.LoadScene("GameScene");
    }
    
    //메뉴버튼 클릭했을때
    public void OnMenuButtonClick()
    {

    }
    
    //옵션버튼 클릭했을때
    public void OnOptionButtonClick()
    {

    }
}
