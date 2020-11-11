using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePoint;
    public float delay = 1f;

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
           GameObject bullet = Instantiate(bulletFactory);
           bullet.transform.position = firePoint.position;
           yield return new WaitForSeconds(delay);
        }

        
    }
}
