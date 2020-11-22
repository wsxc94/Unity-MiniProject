using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniFire : MonoBehaviour
{
    public float speed = 10;
    public float radius = 1;
    public float delay = 1.0f;

    public Transform firePoint = null;
    public GameObject bulletfactory = null;

    public GameObject parent = null;


    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(parent.transform.position, Vector3.up, speed * Time.deltaTime);
    }
    IEnumerator Attack()
    {
        while (true)
        {
            var bullet = ObjectPool.getBullet();
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            //bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(delay);
        }
    }
}
