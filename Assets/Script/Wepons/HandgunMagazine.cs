using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunMagazine : MonoBehaviour
{

    [SerializeField] private int m_bulletCount;//�e�̐�
    /// <summary>
    /// �O���ɒe�̐��𐔂�Ԃ��Q�b�^�[
    /// </summary>


    public int BulletCount
    {
        get { return m_bulletCount; }
    }
    /// <summary>
    /// �}�K�W�������Ă邩���Z�b�g����
    /// </summary>
    /// <param name="canGrip">���Ă邩�ۂ�</param>
    private void SetGripflag(bool canGrip)
    {

    }
    /// <summary>
    ///�e�̐����P���炷
    ///���e�����炷�̏����́A�}�K�W������e�̃X���C�h�������đ���ۂ̏���
    /// </summary>
    public void ConsumeOneShot()
    {
        if (m_bulletCount <= 0) return;

        m_bulletCount--;
        Debug.Log(m_bulletCount);

    }

}
