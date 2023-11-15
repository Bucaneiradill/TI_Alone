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
    public Interactable interactable;

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
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
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
            RightButton(interactable, rayCastHit.point);
            LeftButton(interactable, rayCastHit.point);
        }
    }
 #region Inputs
    void RightButton(Interactable newTarget, Vector3 point){
            if (Input.GetMouseButtonDown(1) && playerActions.canAct)
            {
                UIManager.instance.ClosePanel();
               // if (interactable != null)
               // {
                    playerActions.SetTarget(interactable, point, 1);
               // } else {
                   // playerActions.RemoveTarget();
                    //playerActions.MoveToPoint(rayCastHit.point);
               // }
            }
    }
    void LeftButton(Interactable newTarget, Vector3 point){
            if (Input.GetMouseButtonDown(0) && playerActions.canAct)
            {
                UIManager.instance.ClosePanel();
               // if (interactable != null)
               // {
                  //  interactable.CollectNoAction();
                    playerActions.SetTarget(interactable, point, 0);
               // } else {
                   // playerActions.RemoveTarget();
                    //playerActions.MoveToPoint(rayCastHit.point);
               // }
            }
    }
   // void SetTarget(Interactable newTarget, Vector3 point)
   // {
     //   playerActions.SetTarget(newTarget);
   // }
   #endregion
}
