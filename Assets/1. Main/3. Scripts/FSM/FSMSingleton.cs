using UnityEngine;

public class FSMSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    private static object m_lock = new object();

    public static T _Inst
    {
        get
        {
            lock(m_lock)
            {
                if(m_instance == null)
                {
                    m_instance = (T) FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1) 
                    {
                        Debug.LogError("--- FSMSingleton error ---");
                        return m_instance;
                    }

                    if(m_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        m_instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();
                        singleton.hideFlags = HideFlags.HideAndDontSave;
                    }
                    else
                    {
                        Debug.LogError("--- FSMSingleton already exist ---");
                    }
                }

                return m_instance;
            }
        }
    }
}
