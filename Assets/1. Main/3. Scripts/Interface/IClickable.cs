using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IClickable
{
    void Click(PlayerManager player, Vector3 hitPos);
}     
