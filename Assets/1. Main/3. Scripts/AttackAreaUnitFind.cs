using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackAreaUnitFind : MonoBehaviour
{
    //public List<GameObject> m_unitList = new List<GameObject>();
    public List<MonsterController> m_unitList = new List<MonsterController>();
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            //if(!m_unitList.Contains(other.gameObject))
            //{
            //    m_unitList.Add(other.gameObject);


            //}

            MonsterController controller = other.gameObject.GetComponent<MonsterController>();
            if (!m_unitList.Contains(controller))
            {
                m_unitList.Add(controller);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            //m_unitList.Remove(other.gameObject);

            MonsterController controller = other.gameObject.GetComponent<MonsterController>();
            m_unitList.Remove(controller);
            //빠지긴 하지만 크기가 줄어들지 않는다.
        }
    }
}
