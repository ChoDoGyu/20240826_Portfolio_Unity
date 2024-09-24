using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaUnitFind : MonoBehaviour
{
    //public List<GameObject> m_unitList = new List<GameObject>();
    public List<MonsterController> m_unitList = new List<MonsterController>();
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            MonsterController controller = other.gameObject.GetComponent<MonsterController>();
            m_unitList.Add(controller);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            MonsterController controller = other.gameObject.GetComponent<MonsterController>();
            m_unitList.Remove(controller);
        }
    }
}
