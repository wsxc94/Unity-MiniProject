using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        //gameObject => 이 스크립트가 할당된 게임오브젝트
    }
}
