using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    enum MOVE_PATTHON { RESPAWN, XZMOVE , CENTER };

    public static Boss Instance;
    public GameObject effect;
    public int Max_hp = 100;
    public int hp = 100;
    public float speed = 5;
    public Image hp_bar;

    public ArrayList wayPoints;
    private Vector3 curPos;
    public float delta = 5.0f;
    private bool direction = false;
    private float time = 0f;

    private MOVE_PATTHON CurrentPatthon;
    private void Start()
    {
        wayPoints = new ArrayList();
        wayPoints.Add(new Vector3(0, 5, 8));
        wayPoints.Add(new Vector3(8, 5, 10));
        wayPoints.Add(new Vector3(-8, 5, 5));
    }
    private void OnEnable()
    {
       
        CurrentPatthon = MOVE_PATTHON.RESPAWN;
        curPos = new Vector3(0, 5, 18);
        transform.position = curPos;
        Instance = this;
        hp = Max_hp;
    }

    public bool getActive()
    {
        return gameObject.activeSelf;
    }
    public void setActive(bool b)
    {
        gameObject.SetActive(b);
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            GameObject ef = Instantiate(effect);
            ef.transform.position = transform.position;
            gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(50);
        }
        move();
        //updateUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            hp--;
            hp_bar.fillAmount = hp * 0.01f;
        }
    }
    void updateUI()
    {
        hp_bar.fillAmount = (float)(hp / Max_hp);

    }

    private void move()
    {
        curPos = transform.position;

        switch (CurrentPatthon)
        {
            case MOVE_PATTHON.RESPAWN:
                transform.position = Vector3.MoveTowards(curPos, (Vector3)wayPoints[0], delta);

                if(Vector3.Distance(transform.position , (Vector3)wayPoints[0]) < 2)
                CurrentPatthon = MOVE_PATTHON.XZMOVE;

                break;

            case MOVE_PATTHON.XZMOVE:              
                if (Vector3.Distance(transform.position, (Vector3)wayPoints[1]) < 2)
                    direction = true;

                if(direction)
                    transform.position = Vector3.MoveTowards(curPos, (Vector3)wayPoints[2], delta);
                else
                    transform.position = Vector3.MoveTowards(curPos, (Vector3)wayPoints[1], delta);

                if (Vector3.Distance(transform.position, (Vector3)wayPoints[2]) < 2)
                {
                    CurrentPatthon = MOVE_PATTHON.CENTER;
                    time = 0f;
                }

                break;
            case MOVE_PATTHON.CENTER:
                transform.position = Vector3.MoveTowards(curPos, (Vector3)wayPoints[0], delta);

                if(Vector3.Distance(transform.position,(Vector3)wayPoints[0]) < 2){
                    time += Time.deltaTime;
                }
                if (time > 5)
                {
                    CurrentPatthon = MOVE_PATTHON.XZMOVE;
                    direction = false;
                    wayPoints[1] = new Vector3(Random.Range(-8f, 8f), 5, Random.Range(10f, 0f));
                    wayPoints[2] = new Vector3(Random.Range(-8f, 8f), 5, Random.Range(10f, 0f));
                }
                break;
            default:
                break;
        }
    }
}
