using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAdapter : EnemyData
{
     public EnemyAdapter(EnemySave enemy){
        position = enemy.transform.position;
        rotation = enemy.transform.rotation;
     }
}
