using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBace : MonoBehaviour
{
    /*弾の速度をインスペクターから変更できること
    弾のダメージをインスペクターから変更できること
    距離減衰なし、生存時間あり5秒
    生成されてから一定速度で正面に飛び続ける*/
    [SerializeField]
    private float m_bulletSpeed;
    [SerializeField]
    private float m_bulletDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();

    }
    //弾をまっすぐ飛ばす
    void BulletMove()
    {
       Vector3 vector =transform.forward* m_bulletSpeed;
        gameObject.transform.position += vector*Time.deltaTime;

    }
}
