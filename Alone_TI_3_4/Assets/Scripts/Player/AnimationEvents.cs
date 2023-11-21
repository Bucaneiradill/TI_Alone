using UnityEngine;

//Classe respos�vel por receber eventos de anima��o

public class AnimationEvents : MonoBehaviour
{
    PlayerActions player;

    private void Start()
    {
        player = GetComponentInParent<PlayerActions>();
    }

    public void DisableActions()
    {
        player?.DisableActions();
    }

    public void EnableActions()
    {
        player?.EnableActions();
    }

    public void Hit()
    {
        player.target.GetComponent<Interactable>().Hit();
    }

    public void ObjectPickUp()
    {
        player.target.GetComponent<Interactable>().ObjectPickUp();
    }
}
