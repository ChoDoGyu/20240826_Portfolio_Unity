using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentInventoryMain : InventoryBase
{
    public static bool m_isInventoryActive = false;

    [Header("���� ���� ��ġ�� ǥ���� �ؽ�Ʈ �󺧵�")]
    [SerializeField] private TextMeshProUGUI m_damageLabel;
    [SerializeField] private TextMeshProUGUI m_defenseLabel;


    new void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyManager.Instance.GetKeyCode("Equipment")))
        {
            if (!m_isInventoryActive)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        m_inventroyBase.SetActive(true);
        m_isInventoryActive = true;
    }

    private void CloseInventory()
    {
        m_inventroyBase.SetActive(false);
        m_isInventoryActive = false;
    }
}
