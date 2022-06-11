using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExp : MonoBehaviour
{
    [SerializeField]
    private float expDestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, expDestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
