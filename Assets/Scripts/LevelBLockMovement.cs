using System;
using UnityEngine;

class LevelBLockMovement : MonoBehaviour
{
    private Vector3 _movementDirection = new Vector3(0, 0, -1);

    private void Start()
    {
        PauseOrDefeatSystem.instance.Subscribe(this);
    }

    private void OnDestroy()
    {
        PauseOrDefeatSystem.instance.Unsubscribe(this);
    }

    private void FixedUpdate()
    {
        transform.Translate(_movementDirection * Time.fixedDeltaTime * GameSettings.instance.GetGameSpeed());
    }
}
