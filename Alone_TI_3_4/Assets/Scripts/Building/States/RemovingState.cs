using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingState : IBuildingState
{
    private int gameObjectIndex = -1;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    SoundFeedback soundFeedback;

    public RemovingState(
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer,
                         SoundFeedback soundFeedback)
    {
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        this.soundFeedback = soundFeedback;
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3 gridPosition)
    {
        //GridData selectedData = null;
        //if (furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one) == false)
        //{
        //    selectedData = furnitureData;
        //}
        //else if (floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one) == false)
        //{
        //    selectedData = floorData;
        //}

        //if (selectedData == null)
        //{
        //    //sound
        //    soundFeedback.PlaySound(SoundType.wrongPlacement);
        //}
        //else
        //{
        //    soundFeedback.PlaySound(SoundType.Remove);
        //    gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
        //    if (gameObjectIndex == -1)
        //        return;
        //    selectedData.RemoveObjectAt(gridPosition);
        //    objectPlacer.RemoveObjectAt(gameObjectIndex);
        //}
        //Vector3 cellPosition = grid.CellToWorld(gridPosition);
        //previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));
    }

    //private bool CheckIfSelectionIsValid(Vector3 gridPosition)
    //{
    //    return !(furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one) &&
    //        floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one));
    //}

    public void UpdateState(Vector3 gridPosition)
    {
        //bool validity = CheckIfSelectionIsValid(gridPosition);
        //previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}