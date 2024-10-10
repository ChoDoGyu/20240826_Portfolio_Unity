using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDontDestroy<T> : MonoBehaviour where T : SingletonDontDestroy<T>
{
    static T m_instance;
    public static T Instance { get { return m_instance; } }
    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = (T)this;
            OnAwake();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (m_instance == this)
        {
            OnStart();
        }
    }

}