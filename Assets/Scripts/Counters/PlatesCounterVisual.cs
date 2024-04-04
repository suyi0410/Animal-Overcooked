using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateVisualGameObjectsList;

    private void Awake()
    {
        plateVisualGameObjectsList = new List<GameObject>();
    }
    
    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
         platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }
    private void PlatesCounter_OnPlateRemoved(object sender, EventArgs e)
    {
        if (plateVisualGameObjectsList.Count > 0)
        {
            GameObject plateGameObject = plateVisualGameObjectsList[plateVisualGameObjectsList.Count - 1];
            plateVisualGameObjectsList.Remove(plateGameObject);
            Destroy(plateGameObject);
        }
    }


    private void PlatesCounter_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);
        
        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0f, plateOffsetY * plateVisualGameObjectsList.Count, 0f);
        
        plateVisualGameObjectsList.Add(plateVisualTransform.gameObject);
    }
}