using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent m_agent;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        //m_agent.updateRotation = false;
    }
    
    public void Set_Dest(Vector3 dest)
    {
        m_agent.SetDestination(dest);
    }
    public void Turn(Vector3 targetPos)
    {
        Vector3 dir = new Vector3(targetPos.x - transform.position.x, 0, targetPos.z - transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), m_agent.angularSpeed);
    }
}
