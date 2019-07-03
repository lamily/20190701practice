using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernaut : MonoBehaviour {
    private AudioSource m_audio;
    public DotaGame dotaGame;
    private GameObject enemyObj;
    void Start()
    {
        m_audio = gameObject.GetComponent<AudioSource>();
       
    }
        void OnGUI()
    {
        if(GUI.Button(new Rect(30, 20, 50, 25), "无敌斩"))
        {
            this.transform.localScale = new Vector3(2f, 2f, 2f);
            Debug.Log("主宰释放了无敌斩技能");
            m_audio.Play();
            dotaGame.quickEnemy();
            StartCoroutine(MoveJuggernaut());

        }
        else
        {
 this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

    }
    private IEnumerator MoveJuggernaut()//Vector3 startPos,Vector3 endPos,float time
    {

        for (int i = 0; i < dotaGame.enemyList.Count;)
        {
            dotaGame.enemyDic.TryGetValue(dotaGame.enemyList[i], out enemyObj);
            Vector3 addPos = new Vector3(0, 0, 1);

            if (dotaGame.enemyList[i] <= 8)
            {            transform.position = Vector3.Lerp(transform.localPosition, enemyObj.transform.position+addPos, 0.5f);
                Debug.Log("销毁了" + enemyObj.name);
                dotaGame.enemyList.RemoveAt(i);
                Destroy(enemyObj);
                m_audio.Play();
            }
            else
            {
                Debug.Log("这个怪物不在击杀范围内");
                yield return null;
            }
             yield return null;  
            yield return new WaitForSeconds(0.5f);
          
        }
       
       
    }

}
