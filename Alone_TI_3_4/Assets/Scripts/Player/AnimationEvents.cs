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
        /*
        Debug.Log(layer.target);
        if(player.target.TryGetComponent<Interactable>(out Interactable obj)){
            obj.Hit();
        }else{
            Debug.Log("Item não interagivel " + obj.gameObject.name);
        }
        */
    }
 
    public void ObjectPickUp()
    {
        /*
        player.target.GetComponent<Interactable>().ObjectPickUp();
        */
    }
}
