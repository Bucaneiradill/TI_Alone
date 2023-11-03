using UnityEngine;

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
}
