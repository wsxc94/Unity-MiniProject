using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour , IPointerDownHandler , IPointerUpHandler , IDragHandler {
    [SerializeField] private RectTransform rect_back= null;
    [SerializeField] private RectTransform rect_joystick = null;

    private float radius;
    [SerializeField] private GameObject player = null;
    [SerializeField] private float moveSpeed = 10f;

    private bool isTouch = false;
    private Vector3 movePos;

    // Start is called before the first frame update
    void Start()
    {
        radius = rect_back.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            player.transform.position += movePos;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_back.position;

        value = Vector2.ClampMagnitude(value , radius);

        rect_joystick.localPosition = value;

        float dis = Vector2.Distance(rect_back.position, rect_joystick.position) / radius;

        value = value.normalized;

        movePos = new Vector3(value.x * moveSpeed * dis * Time.deltaTime, 0f, value.y * moveSpeed * dis * Time.deltaTime);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_joystick.localPosition = Vector3.zero;
        movePos = Vector3.zero;
    }
}
