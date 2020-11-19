using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
    public float speed = 10.0f;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > Camera.main.orthographicSize 
            || transform.position.z < -Camera.main.orthographicSize
            || transform.position.x > Camera.main.orthographicSize
            || transform.position.x < -Camera.main.orthographicSize) Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        //gameObject => 이 스크립트가 할당된 게임오브젝트
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") Destroy(gameObject);
    }
}
