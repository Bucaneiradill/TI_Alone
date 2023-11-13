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
        if (player.target.GetType() == typeof(ColectableSource))
        {
            player.target.GetComponent<ColectableSource>().Hit();
        }
    }

    public void ObjectPickUp()
    {
        if (player.target.GetType() == typeof(Object))
        {
            player.target.GetComponent<Object>().ObjectPickUp();
        }
    }
}
