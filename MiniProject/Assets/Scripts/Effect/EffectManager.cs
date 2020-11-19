using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private float time = 1f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0) Destroy(gameObject);
    }
}
