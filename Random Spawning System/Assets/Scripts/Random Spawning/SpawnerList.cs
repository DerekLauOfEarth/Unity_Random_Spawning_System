/* 
----- Identification -----
Date Created: 11/11/2021
Developer: Derek
Date Last Updated:
Last Update Dev:
-----------------------------
*/

/* 
----- Change Log -----
v0.0.0 - Initial Script
----------------------
*/

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents List of GameObject to spawn
/// Interacts with ObjectPooler & Spawner class
/// </summary>
[CreateAssetMenu(fileName = "New SpawnerList", menuName = "Spawner List")]
public class SpawnerList : ScriptableObject
{
    /// <summary>
    /// Entity Speed & Entity list
    /// </summary>
    [Header("Entity list")]
    [Tooltip("Determines how fast the Entity moves")]
    public float EntitySpeed;
    public List<EntitySpawnStruct> EntitySpawnList;
    
    /// <summary>
    /// Entity details
    /// </summary>
    [System.Serializable]
    public struct EntitySpawnStruct
    {
        /// <summary>
        /// Entity ObjectPooler component reference
        /// </summary>
        [Tooltip("Insert Entity ScriptableObject")]
        public Entity EntityScpObj;
        
        /// <summary>
        /// Entity's spawn rate
        /// </summary>
        [Tooltip("Entity's spawn rate")]
        public float SpawnRate;
    }
    
    /// <summary>
    /// PickUp list
    /// </summary>
    [Header("PickUp list")]
    public List<PickUpSpawnStruct> PickUpSpawnList;
    
    /// <summary>
    /// PickUp details
    /// </summary>
    [System.Serializable]
    public struct PickUpSpawnStruct
    {
        /// <summary>
        /// Pickup ScriptableObject
        /// </summary>
        [Tooltip("Insert Pickup's ScriptableObject")]
        public Pickup PickupScpObj;
        
        /// <summary>
        /// PickUp's spawn rate
        /// </summary>
        [Tooltip("PickUp's spawn rate")]
        [Range(0,1)]
        public float SpawnRate;
    }
}

