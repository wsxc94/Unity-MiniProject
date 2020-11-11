using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(- (Vector3.forward * speed * Time.deltaTime));

        if(transform.position.z <= -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        //gameObject => 이 스크립트가 할당된 게임오브젝트
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "bullet")
        {
            Destroy(gameObject);
            if (other.tag == "bullet")
                Destroy(other.gameObject);
        }
    }

}
