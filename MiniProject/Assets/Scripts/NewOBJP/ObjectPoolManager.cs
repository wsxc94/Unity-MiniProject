using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonBase<ObjectPoolManager>
{
    [SerializeField]
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

    //public void InitObjectPool(string name) // 오브젝트풀에 적재되어있는 모든 것 없애기
    //{
    //    if(objectPool.TryGetValue(name, out Queue<GameObject> objectList))
    //    {
    //        objectPool.Clear();
    //    }
    //}

    public GameObject GetObject(string name)  // 오브젝트풀에 적재되어있는 게임오브젝트 반환
    {
        if (objectPool.TryGetValue(name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
                return CreateNewObject(Resources.Load("Prefabs/" + name) as GameObject);
            else
            {
                GameObject _object = objectList.Dequeue();
                _object.SetActive(true);
                return _object;
            }
        }
        else
            return CreateNewObject(Resources.Load("Prefabs/" + name) as GameObject);

    }

    public void InitObject(string name , int cnt) //오브젝트풀에 카운트만큼 미리 만들어두는 함수
    { 

            for (int i = 0; i < cnt; i++)
            {
                GameObject obj = Instantiate(Resources.Load("Prefabs/" + name) as GameObject);
                obj.name = name;
                ReturnObject(obj);
            }         
    }

    private GameObject CreateNewObject(GameObject gameObject) // 게임오브젝트 새로만드는 함수
    {
        GameObject newGO = Instantiate(gameObject);
        newGO.name = gameObject.name;
        return newGO;
    }

    public void ReturnObject(GameObject gameObject) // 사용하던 게임오브젝트를 오브젝트풀에 반환
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, newObjectQueue);
        }

        gameObject.SetActive(false);

    }

}
