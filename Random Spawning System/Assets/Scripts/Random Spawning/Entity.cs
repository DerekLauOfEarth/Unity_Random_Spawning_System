/* 
----- Identification -----
Date Created: 11/11/2021
Developer: Derek
Date Last Updated:
Last Update Dev:
--------------------------
*/

/* 
----- Change Log -----
v0.0.0 - Initial Script
----------------------
*/

using System;
using UnityEngine;

/// <summary>
/// Represents Entity's behaviour details
/// Interacts with EntityMovement class
/// </summary>
[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    /// <summary>
    /// Input corresponded entity's prefab here
    /// </summary>
    [Tooltip("Entity prefab")]
    public GameObject EntityPrefab;
    
    /// <summary>
    /// Input corresponded entity pooler ScriptableObject here
    /// </summary>
    [Tooltip("Object Pooler that manage this entity.")]
    public ObjectPooler EntityPooler;

    /// <summary>
    /// Determines if Entity supports PickUp spawning above it
    /// </summary>
    [Tooltip("Determines if Entity supports PickUp")]
    public bool AllowPickUp;

}
