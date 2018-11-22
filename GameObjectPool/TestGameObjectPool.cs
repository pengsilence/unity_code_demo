using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class TestGameObjectPool : MonoBehaviour
{
    public GameObject[] prefabObj;
    public string[] Objnm = { "Cube", "Sphere" };
    GameObjectPool gop = null;
    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 obj_pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            gop = GameObjectPool.instance;
        }       
    }

    private void OnGUI()
    {
        if (GUILayout.Button("创建"))
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 obj_pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                gop.CreateObject(Objnm[i], prefabObj[i], obj_pos, Quaternion.identity);
            }
        }
        if (GUILayout.Button("释放"))
        {
            gop.Clear("Cube");
        }
        if (GUILayout.Button("实时回收"))
        {
            gop.CollectObject(GameObject.FindGameObjectWithTag("Cube"));
        }
        if (GUILayout.Button("延时回收"))
        {
            gop.CollectObject(GameObject.FindGameObjectWithTag("Cube"), 5.0f);
        }
    }
}
