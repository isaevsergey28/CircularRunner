using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMarker : MonoBehaviour
{
    [SerializeField] private int _countLevelSide;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.color = Color.white;
    }
        
    public int GetSide()
    {
        return _countLevelSide - 1;
    }
}
