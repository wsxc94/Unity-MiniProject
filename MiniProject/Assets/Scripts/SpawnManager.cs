using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] plane;
    bool isActive = true;

    // Update is called once per frame
    void Update()
    {
        AirPlaneSpawn();
    }

    void AirPlaneSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
           if (isActive)
            {
                for (int i = 0; i < 2; i++)
                {
                    plane[i].SetActive(false);
                    isActive = false;
                }
            }
           else
            {
                for (int i = 0; i < 2; i++)
                {
                    plane[i].SetActive(true);
                    isActive = true;
                }
            }

            
        }
    }
}
