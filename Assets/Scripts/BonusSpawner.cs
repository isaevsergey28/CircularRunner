using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allBonusesPrefabs;
    [SerializeField] private List<BonusMarker> _allBonusesMarkers;
    
    private void Start()
    {
        _allBonusesMarkers = GetComponentsInChildren<BonusMarker>().ToList();
        SpawnBonuses();
    }

    private void SpawnBonuses()
    {
        foreach (var bonusesMarker in _allBonusesMarkers)
        {
            if (Random.Range(0, 8) == 1)
            {
                GameObject bonusesPrefab = _allBonusesPrefabs[Random.Range(0, _allBonusesPrefabs.Length)];
                GameObject bonus = Instantiate(bonusesPrefab, bonusesMarker.transform.position, Quaternion.identity, transform);
                bonus.transform.Rotate(new Vector3(0, 0, 60 * bonusesMarker.GetSide() + transform.root.transform.eulerAngles.z));
            }
        }
    }
}