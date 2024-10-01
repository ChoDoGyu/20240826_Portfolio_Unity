using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    PlayerManager m_player;

    [SerializeField, Header("HP��")]
    Slider m_hpSlider;
    [SerializeField, Header("ü�� ��ġ")]
    TextMeshProUGUI m_hpText;
    private void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        HPControl();
    }
    void HPControl()
    {
        //ü�¹�
        m_hpSlider.maxValue = m_player.m_playerStaus.m_hp;
        m_hpSlider.value = m_player.m_hpManager.m_hp;
        m_hpText.text = m_hpSlider.value.ToString() + "/" + m_hpSlider.maxValue.ToString();
    }
}
