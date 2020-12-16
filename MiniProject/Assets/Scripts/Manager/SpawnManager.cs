using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] mini;
    public GameObject enemyFactory = null;
    private float time = 0;

    private void Awake()
    { 
    }
    void Start()
    {
        ObjectPoolManager.Instance.InitObject("StoneMonster", 20);
        StartCoroutine(EnemySpawn());
    }
    private void OnEnable()
    {
        //StartCoroutine(EnemySpawn());
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsActive == true && GameManager.Instance.myGameManager.activeSelf == true)
        {
            StartCoroutine(EnemySpawn());
            GameManager.Instance.IsActive = false;
        }

        AirPlaneSpawn();
        //BossSpawn();
    }
    void BossSpawn()
    {
        if (!Boss.Instance.getActive())
        {
            time += Time.deltaTime;
            if(time > 5)
            {
                Boss.Instance.setActive(true);
                Boss.Instance.hp = Boss.Instance.Max_hp;
                time = 0;
            }
        }
    }
    void AirPlaneSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            for (int i = 0; i < mini.Length; i++)
            {
                if(mini[i].activeSelf)
                {
                    mini[i].SetActive(false);
                }
                else
                {
                    mini[i].SetActive(true);
                }
            }
            
        }
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
          GameObject enemy = ObjectPoolManager.Instance.GetObject("StoneMonster");
        enemy.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 5.0f, 15.0f);
        yield return new WaitForSeconds(1.0f);

        }
    }
}
