using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    private GameObjectPool() { }

    private static GameObjectPool goSingle;
    public static GameObjectPool instance
    { 
        get
        {
            if (goSingle == null)
            {
                goSingle = GameObject.FindObjectOfType(typeof(GameObjectPool)) as GameObjectPool;
                if (goSingle == null)
                {
                    goSingle = new GameObject("Singleton of " + typeof(GameObjectPool).ToString(), typeof(GameObjectPool)).GetComponent<GameObjectPool>();
                }
            }
            return goSingle;
        }
    }

    private Dictionary<string,List<GameObject>> goCache = new Dictionary<string, List<GameObject>>();
    public GameObject CreateObject(string Key,GameObject go,Vector3 pos,Quaternion rotat)
    {
        /* 游戏对象池使用的基本原理：
         * 1.若已存在，则获取使用；
         * 2.若不存在，则动态生成，放入池中，再返回
         */
        GameObject tagGo = FindValue(Key);
        if (tagGo != null)
        {
            tagGo.transform.position = pos;
            tagGo.transform.rotation = rotat;
            tagGo.SetActive(true);
        }
        else
        {
            tagGo = Instantiate(go, pos, rotat) as GameObject;
            AddGameObject(Key, tagGo);
        }

        //动态加载(生成)的gameobject,将当前物体this为父物体
        tagGo.transform.parent = this.transform;
        return tagGo;
    }

    private GameObject FindValue(string Ky)
    {
        if (goCache.ContainsKey(Ky))
        {
            /*goCache是dictionary，goCache[Ky]则是List
              即：在goCache[Ky]列表中查找active属性为false(未激活/未使用)
            */
            return goCache[Ky].Find((p) => !p.activeSelf);
        }
        else
            return null;
    }

    private void AddGameObject(string Ky,GameObject addgo)
    {
        if (!goCache.ContainsKey(Ky))
        {
            goCache.Add(Ky, new List<GameObject>()); //增加一个键，没有值
        }
        goCache[Ky].Add(addgo); 
    }

    //根据Key值将GameObject从池中删除，注意：还要将Scene中的对象Destory掉
    public void Clear(string Ky)
    {
        if (goCache.ContainsKey(Ky))
        {
            foreach (var item in goCache[Ky])
            {
                Destroy(item);
            }
            goCache.Remove(Ky);
        }
    }

    public void ClearAll()
    {
        //string[] keysArr = new string[goCache.Keys.Count];
        //goCache.Keys.CopyTo(keysArr, 0);
        //foreach (var item in keysArr)
        //{
        //  Clear(item);
        //}
        //或
        //for (int i = 0; i < goCache.Keys.Count; i++)
        //{
        //  Destroy(goCache[keysArr[i]]);
        //}

        List<string> KyList = new List<string>(goCache.Keys);
        foreach (var item in KyList)
        {
            Clear(item);
        }
    }

    /* 回收对象：使用完对象返回对象池中(从Scene中消失)
     * 即时回收，本质就是从Scene中消失
     */
    public void CollectObject(GameObject Collgo)
    {
        Collgo.SetActive(false);
    }

    //延时回收(使用协程)
    public void CollectObject(GameObject Collgo,float delayTime)
    {
        StartCoroutine(DelayCollect(Collgo, delayTime));
    }

    private IEnumerator  DelayCollect(GameObject Delaygo, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        CollectObject(Delaygo);
    }
}
