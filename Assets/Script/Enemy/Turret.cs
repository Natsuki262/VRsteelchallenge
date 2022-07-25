using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyBase
{
    //’e
    [SerializeField]
    private GameObject m_enemyBulletPrefab;
    [SerializeField]
    private GameObject m_muzzle;
    [SerializeField]
    private ObjPoolCtr m_objPoolCtr;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("BulletInstantiate", 1f);
    }


    // Update is called once per frame
    void Update()
    {
       
    }
   /* private void BulletInstantiate()
    {
        GameObject obj=m_objPoolCtr.GetPoolObj();
        if (obj == null) { return; }
        obj.transform.position=m_muzzle.transform.position; 
        obj.transform.rotation=m_muzzle.transform.rotation;
        obj.SetActive(true);

    }*/
    
}
