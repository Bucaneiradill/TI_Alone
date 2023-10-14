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

    //adiciona uma missão na lista
    public void AddQuest(Quest quest)
    {
        availableQuests.Add(quest);
    }

    //remove uma missão da lista
    public void CompleteQuest(Quest quest)
    {
        availableQuests.Remove(quest);
        UIManager.instance.DisplayAction($"Missão '{quest.title}' concluída!");
    }

    public void UpdateCollectQuests()
    {
        List<Quest> finishedQuests = new();
        foreach(Quest quest in availableQuests)
        {
            quest.goal.ItemCollected();
            if (quest.goal.IsReached())
            {
                finishedQuests.Add(quest);
            }
        }
        foreach(Quest quest in finishedQuests)
        {
            CompleteQuest(quest);
        }
    }
}
