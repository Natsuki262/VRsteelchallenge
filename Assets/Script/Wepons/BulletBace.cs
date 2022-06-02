using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBace : MonoBehaviour
{

    //�e��
    [SerializeField]
    private float m_bulletSpeed = 0.0f;
    //�e�̃_���[�W
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
    //�e���܂�������΂�
    void BulletMove()
    {
        Vector3 vector = transform.forward * m_bulletSpeed;
        gameObject.transform.position += vector * Time.fixedDeltaTime;
    }
    //�e����o��Ray�ɐڐG�������̂�Ԃ�
    GameObject BulletRaycastHit()
    {

        //�Փ˂����I�u�W�F�N�g�̏���ۑ�����ϐ�
        RaycastHit bulletHit;

        //�ڐG����
        int layerMask = (1 << 9) + (1 << 13);
        Vector3 origin = transform.position;//Ray�̊J�n�n�_
        Vector3 direction = transform.TransformDirection(Vector3.forward);//Ray�̕���
        float maxDistance = m_bulletSpeed * Time.fixedDeltaTime;//Ray���Փ˔��������ő勗��
        bool isHit = Physics.Raycast(origin, direction, out bulletHit, maxDistance, layerMask);
        Debug.DrawRay(origin, direction * maxDistance, Color.white, 0, false);
        //Ray�̕`��

        //�ڐG�����I�u�W�F�N�g��Ԃ�
        if (isHit)
        {
            Debug.Log("hit");
            return bulletHit.collider.gameObject;//�ڐG�����I�u�W�F�N�g��Ԃ�
        }
        else
        {
            return null;
        }

    }
    /// <summary>
    /// �_���[�W��^����
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
