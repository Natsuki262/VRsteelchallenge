using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{
    [SerializeField]
    GameObject m_prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>�I�u�W�F�N�g����</summary>
    public void InstantiateObject()
    {
        Instantiate(m_prefab, transform.position, transform.rotation);

    }
}
