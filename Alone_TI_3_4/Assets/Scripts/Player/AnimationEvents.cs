using UnityEngine;

//Classe resposável por receber eventos de animação

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
        Debug.Log("DisableActions");
    }

    public void EnableActions()
    {
        player?.EnableActions();
        Debug.Log("EnableActions");
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
