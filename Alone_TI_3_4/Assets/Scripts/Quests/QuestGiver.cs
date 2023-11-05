using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    private void Start()
    {
        QuestManager.instance.AddQuest(quest);
    }

    public void EnableQuest()
    {
        QuestManager.instance.AddQuest(quest);
    }
}
