using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBace : MonoBehaviour
{
    /*�e�̑��x���C���X�y�N�^�[����ύX�ł��邱��
    �e�̃_���[�W���C���X�y�N�^�[����ύX�ł��邱��
    ���������Ȃ��A�������Ԃ���5�b
    ��������Ă����葬�x�Ő��ʂɔ�ё�����*/
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
    //�e���܂�������΂�
    void BulletMove()
    {
       Vector3 vector =transform.forward* m_bulletSpeed;
        gameObject.transform.position += vector*Time.deltaTime;

    }
}
