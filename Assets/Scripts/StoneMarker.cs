using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMarker : MonoBehaviour
{
    [SerializeField] private int _countLevelSide;
    
    private void Start()
    {
        transform.Rotate(new Vector3(0, 0, 60 * _countLevelSide - 1));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.color = Color.white;
    }
    
            
    public int GetSide()
    {
        return _countLevelSide - 1;
    }
}
