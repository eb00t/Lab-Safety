using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysMat : MonoBehaviour
{
    public PlayerManager playerManager;

    public void JumpSwap(int changeTo)
    {
        switch (changeTo)
        {
            case 0:
                playerManager.jumpForce = 5;
                break;
            case 1:
                playerManager.jumpForce = 20;
                break;
            default:
                playerManager.jumpForce = 20;
                break;
        }
       
    }
}
