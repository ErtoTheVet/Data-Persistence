using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DeathZone : MonoBehaviour
{
    [FormerlySerializedAs("Manager")] public MainManagerX managerX;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        managerX.GameOver();
    }
}
