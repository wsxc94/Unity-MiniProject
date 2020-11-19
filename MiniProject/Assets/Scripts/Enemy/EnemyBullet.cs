using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject target;
    public GameObject effect;
    public float speed = 3.0f;

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position - transform.position;
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if (target == null) Destroy(gameObject);
    }

    void move()
    {
        
        transform.Translate(dir * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            GameObject ef = Instantiate(effect);
            ef.transform.position = transform.position;

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
