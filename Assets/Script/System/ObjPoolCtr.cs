using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolCtr : MonoBehaviour
{
    /// <summary>
    /// ’™‚ß‚Ä‚¨‚­‚à‚Ì
    /// </summary>
    [SerializeField]
    GameObject poolObj;
    /// <summary>
    /// ’™‚ß‚Ä’u‚­ŒÂ”
    /// </summary>
    [SerializeField]
    int poolNum;
    /// <summary>
    /// ŠÇ—‚µ‚â‚·‚¢‚æ‚¤‚ÉƒŠƒXƒg‰»
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
        for (int i = 0; i < poolList.Count; i++)
        {
            if (true)
            {

            }
        }
        return poolObj;
    }

}
