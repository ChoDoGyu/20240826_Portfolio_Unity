using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager m_instance;
    public static UIManager Instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }

    [SerializeField]
    PlayerManager m_player;

    [SerializeField, Header("HP바")]
    Slider m_hpSlider;
    [SerializeField, Header("체력 수치")]
    TextMeshProUGUI m_hpText;

    [SerializeField, Header("리스폰 창")]
    public GameObject m_respawn;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        m_respawn.SetActive(false);
    }
    void Update()
    {
        HPControl();
       
    }
    void HPControl()
    {
        //체력바
        m_hpSlider.maxValue = m_player.m_playerStaus.m_hp;
        m_hpSlider.value = m_player.m_hpManager.m_hp;
        m_hpText.text = m_hpSlider.value.ToString() + "/" + m_hpSlider.maxValue.ToString();
    }
}
