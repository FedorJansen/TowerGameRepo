using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerBeanScript : MonoBehaviour
{
    public Transform target;
    public float range;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
      //  GetComponent<spawnManager>().enemyPrefabs[];
    }

    void Update()
    {
        
    }

    void UpdateTarget()
    {

        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
