using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePoint;
    public float delay = 1f;
    public float angle { get; set; }

    int[] count = { 0, 45, 90, 135 };

    private void OnEnable()
    {
        
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {

            //for (int i = 0; i < 36; i++)
            //{
            //    GameObject bullet = Instantiate(bulletFactory, firePoint.position, Quaternion.Euler(0f, (360 / 36) * i, 0f));
            //}

            for (int i = 0; i < count.Length; i++)
            {
            GameObject bullet = Instantiate(bulletFactory, firePoint.position, Quaternion.Euler(0f, (360 / 36) * count[i], 0f));
            }


            for (int i = 0; i < count.Length; i++)
            {
                count[i]++;
                if (count[i] > 180)
                {
                    count[i] = 0;
                }
            }
            
            yield return new WaitForSeconds(delay);
        }
    }
}
