using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField]
    Animator m_aniator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>ActiVatedされたらAnimationをm_animatorのTriggerを起動して再生</summary>
    public void Activated()
    {
        m_aniator.SetTrigger("Trigger");
    }
}
