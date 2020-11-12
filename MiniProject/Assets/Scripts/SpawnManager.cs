using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] mini;
    public GameObject enemyFactory;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    // Update is called once per frame
    void Update()
    {
        AirPlaneSpawn();
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
        GameObject enemy = Instantiate(enemyFactory);
        enemy.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 5.0f, 15.0f);
        yield return new WaitForSeconds(1.0f);

        }
    }
}
