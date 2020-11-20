using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ATKPATTHON {ATK1,ATK2,ATK3 }

public class bossAttack : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePoint;
    public float delay = 1f;
    public float angle { get; set; }
    ATKPATTHON curATK;
    private float time = 0;
    private int rnd = 0;

    int[] count = { 0, 45, 90, 135 };

    private void OnEnable()
    {
        time = 0;
        curATK = ATKPATTHON.ATK1;
        StartCoroutine(Attack());
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 5)
        {
            time = 0;
            rnd = Random.Range(0, 3);

            switch (rnd)
            {
                case 0:
                    curATK = ATKPATTHON.ATK1;
                    delay = 0.2f;
                    break;
                case 1:
                    curATK = ATKPATTHON.ATK2;
                    delay = 0.5f;
                    break;
                case 2:
                    curATK = ATKPATTHON.ATK3;
                    delay = 0.1f;
                    break;
                default:
                    curATK = ATKPATTHON.ATK1;
                    break;
            }
        }

    }
    IEnumerator Attack()
    {
        
        while (true)
        {
            switch (curATK)
            {
                case ATKPATTHON.ATK1:
                    FourDirAtk();
                    break;
                case ATKPATTHON.ATK2:
                    CircleAtk();
                    break;
                case ATKPATTHON.ATK3:
                    RndAtk();
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(delay);
        }
    }
    void FourDirAtk()
    {
        for (int i = 0; i < count.Length; i++)
        {
            GameObject bullet = Instantiate(bulletFactory, firePoint.position, Quaternion.Euler(0f, (360 / 36) * count[i], 0f));
        }

        for (int i = 0; i < count.Length; i++)
        {
            count[i]++;
            if (count[i] > 180)
            {
                count[i] = 0;
            }
        }
    }
    void CircleAtk()
    {
        for (int i = 0; i < 36; i++)
        {
            GameObject bullet = Instantiate(bulletFactory, firePoint.position, 
                Quaternion.Euler(0f, (360 / 36) * i, 0f));
        }
    }

    void RndAtk()
    {
       for(int i = 0; i < 2; i++)
        {
            GameObject bullet = Instantiate(bulletFactory, firePoint.position, 
                Quaternion.Euler(0f, (360 / 36) * Random.Range(0f, 360f), 0f));
        }
    }
}
