using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject myGameManager { get; set; }
    public bool IsActive { get; set; }

    private void Awake()
    {
        Instance = this;
        myGameManager = GameObject.Find("GameManager");
    }
    private void OnEnable()
    { 
    }
    // Start is called before the first frame update
    void Start()
    {
        IsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
