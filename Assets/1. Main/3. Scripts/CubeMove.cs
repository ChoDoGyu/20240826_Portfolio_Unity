using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    public GameObject m_obj;

    Rigidbody m_rigidbody;

    public float m_power = 5f;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Vector3 dir = m_obj.transform.position - transform.position;
            dir.y = 0f;
            //
            transform.rotation = Quaternion.LookRotation(dir.normalized);

            m_rigidbody.MovePosition(transform.position - dir.normalized * m_power);
        }

    }
}
