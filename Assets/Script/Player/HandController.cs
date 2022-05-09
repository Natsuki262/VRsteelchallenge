using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandController : MonoBehaviour
{
   
    private Animator m_anime;
    [SerializeField]
    private InputActionProperty m_inputAction;
    // Start is called before the first frame update
    void Start()
    {
        m_anime=gameObject.GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //VR機器のグリップボタンがどれぐらいの強さで押されてるかを取得
        float gripPres = m_inputAction.action.ReadValue<float>();
        if(gripPres>0.1)
        {
            m_anime.SetBool("b_open", true);
        }
        else
        {
            m_anime.SetBool("b_open", false);
        }
    }   
}
