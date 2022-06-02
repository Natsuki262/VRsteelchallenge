using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBace : MonoBehaviour
{

    //弾速
    [SerializeField]
    private float m_bulletSpeed = 0.0f;
    //弾のダメージ
    [SerializeField]
    private float m_bulletDamage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        BulletMove();
        GameObject go;
        go = BulletRaycastHit();
        Debug.Log(go);
        SendDamage(go);
        if (go!=null)
        {
            Destroy(gameObject);
        }

    }
    //弾をまっすぐ飛ばす
    void BulletMove()
    {
        Vector3 vector = transform.forward * m_bulletSpeed;
        gameObject.transform.position += vector * Time.fixedDeltaTime;
    }
    //弾から出るRayに接触したものを返す
    GameObject BulletRaycastHit()
    {

        //衝突したオブジェクトの情報を保存する変数
        RaycastHit bulletHit;

        //接触判定
        int layerMask = (1 << 9) + (1 << 13);
        Vector3 origin = transform.position;//Rayの開始地点
        Vector3 direction = transform.TransformDirection(Vector3.forward);//Rayの方向
        float maxDistance = m_bulletSpeed * Time.fixedDeltaTime;//Rayが衝突判定をする最大距離
        bool isHit = Physics.Raycast(origin, direction, out bulletHit, maxDistance, layerMask);
        Debug.DrawRay(origin, direction * maxDistance, Color.white, 0, false);
        //Rayの描画

        //接触したオブジェクトを返す
        if (isHit)
        {
            Debug.Log("hit");
            return bulletHit.collider.gameObject;//接触したオブジェクトを返す
        }
        else
        {
            return null;
        }

    }
    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="hitObject"></param>
    void SendDamage(GameObject hitObject)
    {
        if (hitObject == null) return;
        EnemyBase enemyScript = hitObject.GetComponent<EnemyBase>();
        if (enemyScript == null) return;
        enemyScript.TakeDamage(m_bulletDamage);
    }
}
