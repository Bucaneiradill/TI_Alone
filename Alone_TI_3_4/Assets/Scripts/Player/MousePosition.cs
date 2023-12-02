using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerActions playerActions;
    public NavMeshAgent agent;
    Interactable interactable;

    [Header("Building")]
    bool buildMode = false;
    public event Action OnClicked, OnExit;
    [SerializeField] private LayerMask placementLayermask;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            return;
        }
        interactable?.HideOutline();
        interactable = null;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            interactable = rayCastHit.collider.gameObject.GetComponentInParent<Interactable>();
            if (interactable != null)
            {
                interactable.ShowOutline();
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
            if (Input.GetMouseButtonDown(0) && playerActions.canAct)
            {
                if (buildMode)
                {
                    OnClicked?.Invoke();
                }
                else
                {
                    if (interactable != null)
                    {
                        SetTarget(interactable);
                    }
                    else
                    {
                        playerActions.RemoveTarget();
                        playerActions.MoveToPoint(rayCastHit.point);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && buildMode) OnExit?.Invoke();
    }

    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPosition()
    {
        return transform.position;
    }

    public void ChangeBuildMode()
    {
        buildMode = !buildMode;
    }

    void SetTarget(Interactable newTarget)
    {
        playerActions.SetTarget(newTarget);
    }
}
