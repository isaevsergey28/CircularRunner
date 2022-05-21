using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerFlashlight playerFlashlight = other.GetComponentInChildren<PlayerFlashlight>();
        if (playerFlashlight)
        {
            playerFlashlight.IncreasePower();
            Destroy(gameObject);
        }
    }
}
