using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;

    [SerializeField]
    private float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * Time.deltaTime * speed);
    }
}
