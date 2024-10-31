using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ground : MonoBehaviour, IClickable
{
    public void Click(PlayerManager player, Vector3 hitPos)
    {
        if (player == null)
            return;
        player.m_moveCheck = true;
        player.m_movePoint = new Vector3(hitPos.x, player.transform.position.y, hitPos.z);
        player.m_monsterController = null;
        //player.m_move.Set_Dest( hitPos);
    }
}
