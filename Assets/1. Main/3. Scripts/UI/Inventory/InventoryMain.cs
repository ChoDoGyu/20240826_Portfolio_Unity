using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMain : InventoryBase
{
    public static bool m_isInventoryActive = false;

    new void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        TryOpenInventory();
    }
    /// <summary>
    /// �κ��丮�� IŰ�� ���� ���ų� �ݴ´�.
    /// </summary>
    private void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyManager.Instance.GetKeyCode("Inventory")))
        {
            if(!m_isInventoryActive)
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

    public void AcquireItem(ItemData item, InventorySlot targetSlot)
    {
        targetSlot.AddItem(item);
        
    }
}
