using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    //verifica se já chegou na quantidade necessária da missão
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    //atualiza o status da missão de coleta
    public void ItemCollected()
    {
        if(goalType == GoalType.Gathering)
        {
            currentAmount++;
        }
    }
}

public enum GoalType
{
    Gathering,
    Crafting
}
