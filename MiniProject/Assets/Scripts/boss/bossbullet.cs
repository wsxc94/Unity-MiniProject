using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject effect;
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
            || transform.position.x < -Camera.main.orthographicSize) ObjectPoolManager.Instance.ReturnObject(gameObject); //Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        //ObjectPool.Return_Bbullet(this);
        //gameObject => 이 스크립트가 할당된 게임오브젝트
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject ef = Instantiate(effect, transform.position, Quaternion.identity);
            ObjectPoolManager.Instance.ReturnObject(gameObject);
            //ObjectPool.Return_Bbullet(this);

            //Destroy(gameObject);
        }
    }
}
