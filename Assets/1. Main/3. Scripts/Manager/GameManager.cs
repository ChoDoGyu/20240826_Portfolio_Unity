using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }
    [SerializeField]
    PlayerManager m_player;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        m_player = FindObjectOfType<PlayerManager>();
    }
    public void IsDie()
    {
        UIManager.Instance.m_respawn.SetActive(true);
    }
    public void Respawn()
    {
        m_player.m_isDie = false;
        UIManager.Instance.m_respawn.SetActive(false);
    }
}
