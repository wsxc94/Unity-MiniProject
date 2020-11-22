using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Button bt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.myGameManager.SetActive(true);
            GameManager.Instance.IsActive = true;
        }
        SceneMgr.Instance.LoadScene("main");
    }
}
