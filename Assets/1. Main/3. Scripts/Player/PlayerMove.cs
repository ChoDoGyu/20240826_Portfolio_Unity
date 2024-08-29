using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public NavMeshAgent m_agent;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        
    }
    
    public void Set_Dest(Vector3 dest)
    {
        m_agent.SetDestination(dest);
    }
}
