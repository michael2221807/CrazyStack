using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE = 65f;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;

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

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE)
        {
            SpawnLevelPart();
        }
    }
}
