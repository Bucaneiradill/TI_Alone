using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    //verifica se j� chegou na quantidade necess�ria da miss�o
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    //atualiza o status da miss�o de coleta
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
