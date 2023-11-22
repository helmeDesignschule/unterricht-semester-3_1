using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance { get; private set; }

    [SerializeField] private GameObject bloodSplatPrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        GameObject.DontDestroyOnLoad(this);
    }

    public void PlayBloodSplat(Vector2 position, Vector2 direction)
    {
        Instantiate(bloodSplatPrefab, position, Quaternion.LookRotation(direction, Vector3.back));
    }
}
