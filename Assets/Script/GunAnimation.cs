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
    /// <summary>ActiVated‚³‚ê‚½‚çAnimation‚ğm_animator‚ÌTrigger‚ğ‹N“®‚µ‚ÄÄ¶</summary>
    public void Activated()
    {
        m_aniator.SetTrigger("Trigger");
    }
}
