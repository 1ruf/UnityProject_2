using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMob : MonoBehaviour
{
   [SerializeField] private float DestroyTime;
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }
}
