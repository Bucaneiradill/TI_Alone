using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public List<Item> specificItem;

    //verifica se já chegou na quantidade necessária da missão
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    //atualiza o status da missão de coleta
    public void ItemCollected(Item item)
    {
        if(goalType == GoalType.Gathering)
        {
            if(specificItem.Count == 0)
            {
                currentAmount++;
                return;
            }
            else if(specificItem.Contains(item))
            {
                currentAmount++;
            }
        }
    }

    public void ItemCrafted(Item item)
    {
        if (goalType == GoalType.Crafting)
        {
            if (specificItem.Count == 0)
            {
                currentAmount++;
                return;
            }
            else if (specificItem.Contains(item))
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
