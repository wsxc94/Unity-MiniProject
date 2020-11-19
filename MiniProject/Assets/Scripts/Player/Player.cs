using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 5.0f;

    public Vector2 margin; // 뷰포트의 좌표는 0,0 1,1 사이의 값을 사용한다.

    float camWidth;
    float camHeight;
    float playerHalfWidth;
    float playerHalfHeight;


    // Start is called before the first frame update
    void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Screen.width / Screen.height;

        Vector3 colHalfSize = GetComponent<Collider>().bounds.extents;
        playerHalfWidth = colHalfSize.x;
        playerHalfHeight = colHalfSize.z;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        //Move();
    }

    //void Move()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
    //    pos.x = Mathf.Clamp(pos.x, 0.0f + margin.x, 1.0f - margin.x);
    //    pos.y = Mathf.Clamp(pos.y, 0.0f + margin.y, 1.0f - margin.y);
    //    transform.position = Camera.main.ViewportToWorldPoint(pos);
    //}


    void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        //Vector3 dir = new Vector3(h, v, 0); 똑같음

        //Vector3.zero = new vector3(0,0,0);
        //Vector3.one = (1, 1, 1);
        //Vector3.right = (1, 0, 0);
        //Vector3.left = (-1, 0, 0);
        //Vector3.up = (0,1,0);
        //Vector3.down = (0 , -1 , 0);
        //Vector3.forward = (0, 0, 1);
        //Vector3.back = (0, 0, -1);

        // 최적화 - 1. 정점 개수 줄이기
        // 2.안쓰는 함수 지우기
        dir = dir.normalized;

        Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;

        movePosition.Set(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth),
                         transform.position.y,
                         Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));

        transform.position = movePosition;
    }

}
