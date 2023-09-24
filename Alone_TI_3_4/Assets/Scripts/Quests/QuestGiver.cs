using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    Quest quest;

    public void EnableQuest()
    {
        quest.isActive= true;
    }
}
