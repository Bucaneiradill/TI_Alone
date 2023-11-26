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
    private Vector3 lastPosition;
    [SerializeField] private LayerMask placementLayermask;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            return;
        }
        if (!buildMode)
        {
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
        else
        {
            if (Input.GetMouseButtonDown(0))
                OnClicked?.Invoke();
            if (Input.GetKeyDown(KeyCode.Escape))
                OnExit?.Invoke();
        }
        
    }

    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, placementLayermask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }

    void SetTarget(Interactable newTarget)
    {
        playerActions.SetTarget(newTarget);
    }
}
