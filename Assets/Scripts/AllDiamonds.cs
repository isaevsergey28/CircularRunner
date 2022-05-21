using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AllDiamonds : MonoBehaviour
{
    [SerializeField] private List<Diamond> _allDiamonds;

    public void AddDiamond(Diamond diamond)
    {
        _allDiamonds.Add(diamond);
    }

    public void RemoveDiamond(Diamond diamond)
    {
        _allDiamonds.Remove(diamond);
    }
} 
