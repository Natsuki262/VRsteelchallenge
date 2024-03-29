using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolCtr : MonoBehaviour
{
    /// <summary>
    /// 貯めておくもの
    /// </summary>
    [SerializeField]
    GameObject poolObj;
    /// <summary>
    /// 貯めて置く個数
    /// </summary>
    [SerializeField]
    int poolNum;
    /// <summary>
    /// 管理しやすいようにリスト化
    /// </summary>
    public List<GameObject> poolList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolNum; i++)
        {
            GameObject obj = Instantiate(poolObj,this.gameObject.transform);
            obj.SetActive(false);
            poolList.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPoolObj()
    {
        //Debug.Log(poolList.Count);
        for (int i = 0; i < poolList.Count; i++)
        {
            if (poolList[i].activeInHierarchy==false)
            {
                return poolList[i];
            }
        }
        return null;
    }

}
