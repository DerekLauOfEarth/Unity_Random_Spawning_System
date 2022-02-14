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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents Pickup's behaviour details
/// Pickup represents items like coin and power-up.
/// </summary>
[CreateAssetMenu(fileName = "New Pickup", menuName = "Pickup")]
public class Pickup : ScriptableObject
{
    /// <summary>
    /// Input corresponded pickup's prefab here
    /// </summary>
    [Tooltip("Pickup prefab")]
    public GameObject PickupPrefab;
    
    /// <summary>
    /// Input corresponded pickup pooler ScriptableObject here
    /// </summary>
    [Tooltip("Object Pooler that manage this pickup.")]
    public ObjectPooler PickupPooler;
}
 