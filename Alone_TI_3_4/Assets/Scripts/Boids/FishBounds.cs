using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBounds : MonoBehaviour
{
    private SphereCollider boundsCollider;

    private void Start()
    {
        boundsCollider = GetComponent<SphereCollider>();

        if (boundsCollider == null)
        {
            Debug.LogWarning("Box Collider not found on the FishBounds object.");
        }
    }

    private void Update()
    {
        // Loop through all fish managed by FlockManager
        foreach (GameObject fish in FlockManager.FM.allFish)
        {
            KeepFishInsideBounds(fish.transform);
        }
    }

    private void KeepFishInsideBounds(Transform fishTransform)
    {
        if (boundsCollider == null)
        {
            return;
        }

        Vector3 fishPosition = fishTransform.position;

        // Check if the fish is outside the bounds of the Box Collider
        if (!boundsCollider.bounds.Contains(fishPosition))
        {
            // Calculate the closest point inside the bounds
            Vector3 closestPoint = boundsCollider.ClosestPoint(fishPosition);

            // Move the fish to the closest point inside the bounds
            fishTransform.position = closestPoint;
        }
    }
}
