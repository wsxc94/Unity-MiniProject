using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField]
    //private float speed = 5.0f;

    //Rigidbody Myrigidbody;


    //float camWidth;
    //float camHeight;
    //float playerHalfWidth;
    //float playerHalfHeight;

    //void Start()
    //{
    //    camHeight = Camera.main.orthographicSize;
    //    camWidth = camHeight * Screen.width / Screen.height;

    //    Vector3 colHalfSize = GetComponent<Collider>().bounds.extents;

    //    playerHalfWidth = colHalfSize.x;
    //    playerHalfHeight = colHalfSize.z;

    //    Myrigidbody = GetComponent<Rigidbody>();
    //}
    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    // 사용자가 어떤 플랫폼을 쓸지 모르니까 (멀티 플랫폼) GetAxis , horizontal , vertical 을 쓴다.
    //    // GetAxis 의 값은 1 ~ -1 사이의 값
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    //transform.Translate(h * speed * Time.deltaTime, x * speed * Time.deltaTime, 0);

    //    //Vector3 dir = Vector3.right * h + Vector3.forward * v;
    //    //Myrigidbody.velocity = dir;
    //    // Camera.main.orthoGraphicsSize  * Screen.Width / Screen.Height
    //    //dir.Normalize();
    //    //transform.Translate(dir * speed * Time.deltaTime);

    //    // P = P + vt  위치 = 현재위치 + (방향 * 시간)
    //    //transform.position = transform.position + dir * speed * Time.deltaTime;

    //    //transform.position += dir * speed * Time.deltaTime;

    //    Vector3 dir = Vector3.right * h + Vector3.forward * v;
    //    dir = dir.normalized;

    //    Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;

    //    movePosition.Set(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth),
    //                     0f,
    //                     Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));

    //    transform.position = movePosition;


    //    //플레이어 화면밖으로 나가지 못하게 막기
    //    //1. 화면밖 공간에 큐브 4개를 만들어서 배치하면 충돌체 때문에 밖으로 벗어나지 못한다.
    //    //2. 플레이어 트랜스폼 포지션 x, y값을 고정시킨다
    //    //3. 메인카메라의 뷰포트를 가져와서 처리한다

    //    //현재 플레이어의 월드좌표를 뷰포트 기준 좌표로 변환시키는 명령
    //    //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

    //    ////입력된 값이 0~1 사이를 벗어나지 못하게 강제로 조정해 주는 함수

    //    //viewPos.x = Mathf.Clamp01(viewPos.x);
    //    //viewPos.y = Mathf.Clamp01(viewPos.y);



    //    //Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);

    //    //transform.position = worldPos;
    //}
    public float speed = 5.0f;

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
    }


    void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = dir.normalized;

        Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;
        movePosition.Set(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth),
                         transform.position.y,
                         Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));

        transform.position = movePosition;
    }

}
