using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePoint;
    public float delay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
    }
    private void Fire()
    {
        if (AtkButton.Instance.isTouch == true)
        {

            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePoint.position;
        }
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.transform.position = firePoint.position;
        //}
    }
    IEnumerator FireCorutine()
    {
        while (true)
        {
            if (AtkButton.Instance.isTouch == true)
            {

                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = firePoint.position;
            }

            yield return new WaitForSeconds(delay);

        }
    }
}
