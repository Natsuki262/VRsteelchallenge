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
    private void FixedUpdate()
    {
        BulletMove();
        BulletRaycastHit();
    }
    //�e���܂�������΂�
    void BulletMove()
    {
        Vector3 vector = transform.forward * m_bulletSpeed;
        gameObject.transform.position += vector * Time.deltaTime;
    }
    void BulletRaycastHit()
    {
        int layerMask = (1 << 9) + (1 << 13);
        RaycastHit bulletHit;
        Vector3 origin = transform.position;
        //origin = Vector3.zero;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        //direction = Vector3.up;
        float maxDistance = Mathf.Infinity;
        //maxDistance = 10;
        bool isHit = Physics.Raycast(origin, direction, out bulletHit, maxDistance, layerMask);
        Debug.DrawRay(origin, direction * maxDistance, Color.white,0,false);
        if (isHit)
        {
            Debug.Log("hit");
        }
    }
}
