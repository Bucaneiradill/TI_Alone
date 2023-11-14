using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public Item specificItem;

    //verifica se j� chegou na quantidade necess�ria da miss�o
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    //atualiza o status da miss�o de coleta
    public void ItemCollected(Item item)
    {
        if(goalType == GoalType.Gathering)
        {
            if(specificItem == null)
            {
                currentAmount++;
                return;
            }
            else if(item == specificItem)
            {
                currentAmount++;
            }
        }
    }
}

public enum GoalType
{
    Gathering,
    Crafting
}
