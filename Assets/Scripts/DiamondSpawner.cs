using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allDiamondsPrefabs;
    [SerializeField] private List<DiamondMarker> _allDiamondsMarkers;
    
    private void Start()
    {
        _allDiamondsMarkers = GetComponentsInChildren<DiamondMarker>().ToList();
        SpawnDiamonds();
    }

    private void SpawnDiamonds()
    {
        foreach (var diamondMarker in _allDiamondsMarkers)
        {
            if (Random.Range(0, 3) == 1)
            {
                GameObject diamondsPrefab = _allDiamondsPrefabs[Random.Range(0, _allDiamondsPrefabs.Length)];
                GameObject diamond = Instantiate(diamondsPrefab, diamondMarker.transform.position, Quaternion.identity, transform);
                diamond.transform.Rotate(new Vector3(0, 0, 60 * diamondMarker.GetSide() + transform.root.transform.eulerAngles.z));
            }
        }
    }
}
