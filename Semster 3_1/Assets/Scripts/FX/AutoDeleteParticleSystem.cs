using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeleteParticleSystem : MonoBehaviour
{
    private ParticleSystem system;
    private void Awake()
    {
        system = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!system.IsAlive())
            Destroy(gameObject);
    }
}
