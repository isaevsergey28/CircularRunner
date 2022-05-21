using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireflySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allFireflyPrefabs;
    [SerializeField] private List<FireflyMarker> _allFireflyMarkers;
    
    private void Start()
    {
        _allFireflyMarkers = GetComponentsInChildren<FireflyMarker>().ToList();
        SpawnFirefly();
    }

    private void SpawnFirefly()
    {
        foreach (var fireflyMarker in _allFireflyMarkers)
        {
            if (Random.Range(0, 10) == 1)
            {
                GameObject fireflyPrefab = _allFireflyPrefabs[Random.Range(0, _allFireflyPrefabs.Length)];
                GameObject fireFly = Instantiate(fireflyPrefab, fireflyMarker.transform.position, Quaternion.identity, transform);
                fireflyPrefab.transform.Rotate(new Vector3(0, 0, 60 * fireflyMarker.GetSide() + transform.root.transform.eulerAngles.z));
            }
        }
    }
}
