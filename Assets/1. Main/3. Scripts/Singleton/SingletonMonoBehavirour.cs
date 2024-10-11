using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehavirour<T> : MonoBehaviour where T : SingletonMonoBehavirour<T>
{
    static T m_instance;
    public static T Instance { get { return m_instance; } }
    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    void Awake()
    {
        if(m_instance == null)
        {
            m_instance = (T)this;
            OnAwake();            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(m_instance == this)
        {
            OnStart();
        }
    }
   
}
