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

using UnityEngine;

/// <summary>
/// Manages Entity's movement
/// </summary>
public class EntityMovement : MonoBehaviour
{
    /// <summary>
    ///  Spawner GameObject reference for its Spawner script's EntitySpeed variable
    /// </summary>
    [Tooltip("Insert Spawner GameObject")]
    public SpawnerList SpawnerList;
        
    private Vector3 moveDirection;

    #region MonoBehaviour Methods
    void OnEnable()
    {
        //Move x+ -> x-
        moveDirection = new Vector3(SpawnerList.EntitySpeed, 0, 0);
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);
    }
    #endregion
}
