using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : Interactable
{
    bool canUse = true;
    float cooldown = 10;
    public override void Interact()
    {
        base.Interact();
        if (canUse)
        {
            canUse = false;
            UIManager.instance.gameObject.GetComponent<SceneFader>().SkipTime();
            StartCoroutine(UseCoolDown());
        }
        else
        {
            UIManager.instance.DisplayAction($"Você só pode dormir a cada {cooldown} segundos");
        }
    }

    IEnumerator UseCoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }
}
