using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quest: ScriptableObject
{
    public string title;
    public string description;
    public QuestGoal goal;
    public Quest nextQuest;
}
