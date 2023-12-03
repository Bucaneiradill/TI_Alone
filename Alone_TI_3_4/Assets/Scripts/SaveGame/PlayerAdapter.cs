using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdapter : PlayerData
{
    public PlayerAdapter(PlayerActions player){
        position = player.transform.position;
        rotation = player.transform.rotation.eulerAngles;
    }
}
