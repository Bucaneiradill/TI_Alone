using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> availableQuests;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance= this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            ResetQuests();
        }
    }

    //adiciona uma missão na lista
    public void AddQuest(Quest quest)
    {
        if(availableQuests.Contains(quest)) return;
        availableQuests.Add(quest);
        UIManager.instance.questTitle.text = quest.title;
        UIManager.instance.questDescription.text = $"{quest.description} (0/{quest.goal.requiredAmount})";
        UIManager.instance.questDescription.fontStyle = TMPro.FontStyles.Normal;
    }

    //remove uma missão da lista
    public void CompleteQuest(Quest quest)
    {
        availableQuests.Remove(quest);
        UIManager.instance.DisplayAction($"Missão '{quest.title}' concluída!");
        if (quest.nextQuest != null) AddQuest(quest.nextQuest);
        quest.goal.currentAmount = 0;
    }

    public void UpdateQuests(Item item)
    {
        List<Quest> finishedQuests = new();
        foreach(Quest quest in availableQuests)
        {
            quest.goal.ItemCollected(item);
            quest.goal.ItemCrafted(item);
            if (quest.goal.IsReached())
            {
                finishedQuests.Add(quest);
            }
            string newDescription = $"{quest.description} ({quest.goal.currentAmount}/{quest.goal.requiredAmount})";
            UIManager.instance.questDescription.text = newDescription;
        }
        foreach(Quest quest in finishedQuests)
        {
            CompleteQuest(quest);
            if (quest.nextQuest == null)
            {
                UIManager.instance.questDescription.fontStyle = TMPro.FontStyles.Strikethrough;
            }
            else
            {
                UIManager.instance.questDescription.fontStyle = TMPro.FontStyles.Normal;
            }
        }
    }

    void ResetQuests()
    {
        foreach(Quest q in availableQuests)
        {
            q.goal.currentAmount = 0;
        }
    }
}
