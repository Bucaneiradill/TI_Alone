using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public static PlacementSystem instance;

    [SerializeField]
    private MousePosition inputManager;

    [SerializeField]
    private ObjectsDatabaseSO database;

    [SerializeField]
    private AudioClip correctPlacementClip, wrongPlacementClip;
    [SerializeField]
    private AudioSource source;

    private GridData floorData, furnitureData;

    [SerializeField]
    private PreviewSystem preview;

    private Vector3Int lastDetectedPosition = Vector3Int.zero;

    [SerializeField]
    private ObjectPlacer objectPlacer;

    IBuildingState buildingState;

    [SerializeField]
    private SoundFeedback soundFeedback;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        floorData = new();
        furnitureData = new();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        buildingState = new PlacementState(ID,
                                           preview,
                                           database,
                                           floorData,
                                           furnitureData,
                                           objectPlacer);
        //soundFeedback);
        inputManager.ChangeBuildMode();
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    public void StartRemoving()
    {
        StopPlacement();
        buildingState = new RemovingState(preview, floorData, furnitureData, objectPlacer, soundFeedback);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();

        buildingState.OnAction(mousePosition);

    }

    //private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    //{
    //    GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? 
    //        floorData : 
    //        furnitureData;

    //    return selectedData.CanPlaceObejctAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    //}

    public void StopPlacement()
    {
        //soundFeedback.PlaySound(SoundType.Click);
        if (buildingState == null)
            return;
        //gridVisualization.SetActive(false);
        buildingState.EndState();
        inputManager.ChangeBuildMode();
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
        lastDetectedPosition = Vector3Int.zero;
        buildingState = null;
    }

    private void Update()
    {
        if (buildingState == null)
            return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        buildingState.UpdateState(mousePosition);

    }
}