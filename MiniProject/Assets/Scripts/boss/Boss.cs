using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static Boss Instance;
    public GameObject effect;
    public int Max_hp = 100;
    public int hp = 100;
    public Image hp_bar;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Max_hp = hp;
    }

    public bool getActive()
    {
        return gameObject.activeSelf;
    }
    public void setActive(bool b)
    {
        gameObject.SetActive(b);
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            GameObject ef = Instantiate(effect);
            ef.transform.position = transform.position;
            gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(50);
        }
        //updateUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            Destroy(other.gameObject);
            hp--;
            hp_bar.fillAmount = hp * 0.01f;
        }
    }
    void updateUI()
    {
        hp_bar.fillAmount = (float)(hp / Max_hp);

    }
}
