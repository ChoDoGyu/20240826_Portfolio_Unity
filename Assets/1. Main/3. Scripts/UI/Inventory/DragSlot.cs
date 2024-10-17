using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    static DragSlot m_instance;
    public static DragSlot Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<DragSlot>();
            }
            return m_instance;
        }
    }

    [HideInInspector]
    public Slot m_currentSlot;
    [SerializeField]
    private Image m_itemImage;

    public void DragSetImage(Image itemImage)
    {
        m_itemImage.sprite = itemImage.sprite;
        SetColor(1);
    }
    public void SetColor(float alpha)
    {
        Color color = m_itemImage.color;
        color.a = alpha;
        m_itemImage.color = color;
    }
}
