using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlacementState : IBuildingState
{
    private int selectedObjectIndex = -1;
    int ID;
    PreviewSystem previewSystem;
    ObjectsDatabaseSO database;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    SoundFeedback soundFeedback;

    public PlacementState(int iD,
                          PreviewSystem previewSystem,
                          ObjectsDatabaseSO database,
                          GridData floorData,
                          GridData furnitureData,
                          ObjectPlacer objectPlacer)
                          //SoundFeedback soundFeedback)
    {
        ID = iD;
        this.previewSystem = previewSystem;
        this.database = database;
        //this.floorData = floorData;
        //this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        //this.soundFeedback = soundFeedback;

        selectedObjectIndex = database.objectsData.FindIndex(data => data.iD == ID);
        if (selectedObjectIndex > -1)
        {
            previewSystem?.StartShowingPlacementPreview(
                database.objectsData[selectedObjectIndex].PrefabItem);
        }
        else
            throw new System.Exception($"No object with ID {iD}");

    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3 position)
    {
        bool placementValidity = previewSystem.placementAvailable;
        if (placementValidity == false)
        {
            //soundFeedback.PlaySound(SoundType.wrongPlacement);
            return;
        }
        //soundFeedback.PlaySound(SoundType.Place);
        objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex], position);
    }

    public void UpdateState(Vector3 position)
    {
        //bool placementValidity = CheckPlacementValidity(position, selectedObjectIndex);

        previewSystem.UpdatePosition(position, true);
    }
}
