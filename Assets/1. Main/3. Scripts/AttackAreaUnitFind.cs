using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaUnitFind : MonoBehaviour
{
    public List<GameObject> m_unitList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            m_unitList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            m_unitList.Remove(other.gameObject);
        }
    }
    private void Update()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
