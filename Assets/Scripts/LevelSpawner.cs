using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allLevelBlocksPrefab;
    [SerializeField] private float _activeLevelBlocksCount = 15;

    private List<GameObject> _activeLevelBocks = new List<GameObject>();
    private float _removeRoadXPos = -10f;

    private void Start()
    {
        for (int i = 0; i < _activeLevelBlocksCount; i++)
        {
            SpawnRoad();
        }
    }

    private void LateUpdate()
    {
        CkeckForSpawn();
    }

    private void CkeckForSpawn()
    {
        foreach (GameObject road in _activeLevelBocks)
        {
            _activeLevelBocks = _activeLevelBocks.Where(i => i != null).ToList();
            if (_removeRoadXPos > road.transform.position.z)
            {
                SpawnRoad();
                DestroyRoad();
            }
        }
    }
    private void SpawnRoad()
    {
        GameObject road = Instantiate(_allLevelBlocksPrefab[Random.Range(0, _allLevelBlocksPrefab.Length)], transform);
        Vector3 roadXPos;
        if (_activeLevelBocks.Count > 0)
        {
            roadXPos = _activeLevelBocks[_activeLevelBocks.Count - 1].transform.position + 
                new Vector3(0, 0, road.GetComponent<Collider>().bounds.max.z * 2);
        }
        else
        {
            roadXPos = new Vector3(0f, 0f, 0f);
        }
        road.transform.position = roadXPos;
        _activeLevelBocks.Add(road);
    }

    private void DestroyRoad()
    {
        Destroy(_activeLevelBocks[0]);
        _activeLevelBocks.RemoveAt(0);
    }
}
