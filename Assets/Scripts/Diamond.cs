using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Diamond : MonoBehaviour
{
    private DiamondScore _diamondScore;

    [Inject]
    private void Construct(DiamondScore diamondScore)
    {
        _diamondScore = diamondScore;
    }
    
    private void Start()
    {
        ////////////
        _diamondScore = FindObjectOfType<DiamondScore>();
        ////////////
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _diamondScore.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
