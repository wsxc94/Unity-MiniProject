using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject bullet = null;
    [SerializeField] private GameObject enemybullet = null;
    [SerializeField] private GameObject bossbullet = null;

    Queue<bullet> P_bulletPool = new Queue<bullet>();
    Queue<EnemyBullet> E_bulletPool = new Queue<EnemyBullet>();
    Queue<bossbullet> B_bulletPool = new Queue<bossbullet>();

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        init(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void init(int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            P_bulletPool.Enqueue(CreateBullet());
            E_bulletPool.Enqueue(CreateEbullet());
            
        }
        for (int i = 0; i < cnt*20; i++)
        {
            B_bulletPool.Enqueue(CreateBbullet());
        }
    }

    private bullet CreateBullet()
    {
        var newObj = Instantiate(bullet).GetComponent<bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    private EnemyBullet CreateEbullet()
    {
        var newObj = Instantiate(enemybullet).GetComponent<EnemyBullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    private bossbullet CreateBbullet()
    {
        var newObj = Instantiate(bossbullet).GetComponent<bossbullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static bullet getBullet()
    {
        if (Instance.P_bulletPool.Count > 0)
        {
            var obj = Instance.P_bulletPool.Dequeue();
            obj.gameObject.SetActive(true);
            //obj.transform.SetParent(null);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateBullet();
            newObj.gameObject.SetActive(true);
            //newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static EnemyBullet getEbullet()
    {
        if (Instance.E_bulletPool.Count > 0)
        {
            var obj = Instance.E_bulletPool.Dequeue();
            obj.gameObject.SetActive(true);
            //obj.transform.SetParent(null);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateEbullet();
            newObj.gameObject.SetActive(true);
            //newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static bossbullet getBbullet()
    {
        if (Instance.B_bulletPool.Count > 0)
        {
            var obj = Instance.B_bulletPool.Dequeue();
            obj.gameObject.SetActive(true);
            //obj.transform.SetParent(null);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateBbullet();
            newObj.gameObject.SetActive(true);
            //newObj.transform.SetParent(null);
            return newObj;
        }
    }
    public static void Return_Pbullet(bullet obj)
    {
        obj.gameObject.SetActive(false);
        //obj.transform.SetParent(Instance.transform);
        Instance.P_bulletPool.Enqueue(obj);
    }
    public static void Return_Ebullet(EnemyBullet obj)
    {
        obj.gameObject.SetActive(false);
        //obj.transform.SetParent(Instance.transform);
        Instance.E_bulletPool.Enqueue(obj);
    }
    public static void Return_Bbullet(bossbullet obj)
    {
        obj.gameObject.SetActive(false);
        //obj.transform.SetParent(Instance.transform);
        Instance.B_bulletPool.Enqueue(obj);
    }

}
