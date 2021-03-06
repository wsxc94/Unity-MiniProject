﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    public GameObject fxEffect;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-(Vector3.up * speed * Time.deltaTime));

        if(transform.position.z <= -Camera.main.orthographicSize)
        {
            ObjectPoolManager.Instance.ReturnObject(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        ObjectPoolManager.Instance.ReturnObject(gameObject);
        //gameObject => 이 스크립트가 할당된 게임오브젝트
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "bullet")
        {
            //Destroy(gameObject);
            ObjectPoolManager.Instance.ReturnObject(gameObject);

            GameObject fx = Instantiate(fxEffect);
            fx.transform.position = transform.position;
            ScoreManager.Instance.AddScore(1);
        }
    }

}
