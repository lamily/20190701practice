//using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DotaGame : MonoBehaviour
{
   
    public GameObject[] heroPrefab ;
    public GameObject[] targetArr;
    public List<float> enemyList;
    public Dictionary<float, GameObject> enemyDic;
    float bossDis;
    int t;
  //  private GameObject enemyObj;
    void Start(){

        for(int i = 0; i < 5; i++)
        {
            float posx = Random.Range(-4.0f, 4.0f);
            float posz = Random.Range(-4.0f, 4.0f);
            int nameNum = Random.Range(0, heroPrefab.Length);
            string heroName = heroPrefab[nameNum].name;
            //Debug.Log("name" + heroName);
            Vector3 heroPos = new Vector3(posx, transform.position.y,posz);
            Vector3 randomRotation = new Vector3(Random.Range(0f, 360f), 0f, 0f);

            CharacterModule.CreateHero(heroName,heroPos,randomRotation);
        }

        for (int i = 0; i < 20; i++)
        {
            float posx = Random.Range(-7.5f, 7.5f);
            float posz = Random.Range(-7.5f, 7.5f);
            Vector3 enemyPos = new Vector3(posx, transform.position.y, posz);
            Vector3 randomRotation = new Vector3(Random.Range(0f, 360f), 0f, 0f);

            CharacterModule.CreateEnemy( enemyPos, randomRotation,i);
        }


        enemyDic = new Dictionary<float, GameObject>();
        enemyList = new List<float>();
        targetArr = GameObject.FindGameObjectsWithTag("Enemy");
      //  quickEnemy();
    }

  public  void quickEnemy()
    {
        Debug.Log("长度" + targetArr.Length);
        for (int i = 0; i < targetArr.Length; i++)
        {
           
            float dis = Vector3.Distance(targetArr[i].transform.localPosition, transform.localPosition);
          
                enemyDic.Add(dis, targetArr[i].gameObject);
        
            Debug.Log(dis);
            if (!enemyList.Contains(dis))
            {
                enemyList.Add(dis);
            }
            if (targetArr[i].name == "Boss")
            {
                bossDis = enemyList[i];
                Debug.Log("boss" + bossDis);
            }
        }
        enemyList.Sort();
        for(int i = 0; i < enemyList.Count; i++)
        {
            Debug.Log("排序后  "+enemyList[i]);
            if (enemyList[i] == bossDis)
            {
                t = i;
                Debug.Log("boss的位置" + t);
               
            }
        }
       //enemyList.Sort();
        Debug.Log("***" + enemyList[t]);
        GameObject obj;
        enemyDic.TryGetValue(enemyList[t], out obj);
        Debug.Log(obj.name);
        Destroy(obj);
        enemyList.RemoveAt(t);
    }
}

