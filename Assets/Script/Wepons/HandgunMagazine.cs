using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunMagazine : MonoBehaviour
{

    [SerializeField] private int m_bulletCount;//弾の数
    /// <summary>
    /// 外部に弾の数を数を返すゲッター
    /// </summary>


    public int BulletCount
    {
        get { return m_bulletCount; }
    }
    /// <summary>
    /// マガジンを持てるかをセットする
    /// </summary>
    /// <param name="canGrip">持てるか否か</param>
    private void SetGripflag(bool canGrip)
    {

    }
    /// <summary>
    ///弾の数を１減らす
    ///※弾を減らすの処理は、マガジンから銃のスライドを引いて送る際の処理
    /// </summary>
    public void ConsumeOneShot()
    {
        if (m_bulletCount <= 0) return;

        m_bulletCount--;
        Debug.Log(m_bulletCount);

    }

}
