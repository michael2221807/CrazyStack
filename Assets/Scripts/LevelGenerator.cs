using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE = 65f;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject landscape;

    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = levelPart_1.Find("EndPosition").position;
        Debug.Log(lastEndPosition);
        SpawnLevelPart();
    }
    
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        //Debug.Log(lastEndPosition);
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) 
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private void SpawnLandscapePart()
    {
        LandscapeGenerator LSG = landscape.GetComponent<LandscapeGenerator>();
        if (LSG != null) 
        {
            LSG.initPosition += new Vector3(0, 0, 100);
            LSG.gameSeed += 1;
            GameObject landScapeChoosen = SpawnLandscapePart(landscape, lastEndPosition);
        }
        
        //Debug.Log(lastEndPosition);
    }
    private GameObject SpawnLandscapePart(GameObject landscapePart, Vector3 spawnPosition)
    {
        GameObject landScapeChoosen = Instantiate(landscapePart, spawnPosition, Quaternion.identity);
        return landScapeChoosen;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE)
        {
            SpawnLevelPart();
            SpawnLandscapePart();
        }
    }
}
