using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePoint;

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
           GameObject bullet = Instantiate(bulletFactory);
           //bullet.transform.position = transform.position;
           bullet.transform.position = firePoint.position;
           yield return new WaitForSeconds(0.3f);
        }

        
    }
}
