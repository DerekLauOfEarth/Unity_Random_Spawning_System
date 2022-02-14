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

using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine;

/// <summary>
/// Manage the spawning of GameObject
/// Interact with ObjectPooler class for spawning
/// </summary>
public class Spawner : MonoBehaviour
{
    
    //Spawner > SpawnerList ScriptableObj > Multiple Entity ScriptableObj that each contains  reference to the corresponded ObjectPooler ScriptableObj
    public SpawnerList SpawnerList;
    
    /// <summary>
    /// Determines the minimum spawning interval.
    /// </summary>
    [Header("Spawner Settings")]
    [Range(0,1)]
    [Tooltip("Determines the minimum spawning interval.")]
    public float MinSpawnInterval;
    
    /// <summary>
    /// Determines the maximum spawning interval. Must be higher than MinSpawnInterval.
    /// </summary>
    [Range(0,1)]
    [Tooltip("Determines the maximum spawning interval. Must be higher than MinSpawnInterval.")]
    public  float MaxSpawnInterval;

    private bool isEntitySpawnable = true;
    private bool isPickUpSpawnable = false;
    private float totalEntitySpawnRate = 0;
    private float totalPickupSpawnRate = 0;
    private Vector3 pickupSpawnHeight = new Vector3(0f, 2.0f, 0f);
    
    #region Monobehaviour Methods
    private void Start()
    {
        //Instantiate the obj in pooler at this attached GameObj position & 
        //Count the total of all spawn rates combined
        foreach (SpawnerList.EntitySpawnStruct entitySpawnStruct in SpawnerList.EntitySpawnList)
        {
            entitySpawnStruct.EntityScpObj.EntityPooler.InitializePool(entitySpawnStruct.EntityScpObj.EntityPrefab, this.transform.position);
            totalEntitySpawnRate += entitySpawnStruct.SpawnRate;
        }
        
        foreach (SpawnerList.PickUpSpawnStruct pickUpSpawnStruct in SpawnerList.PickUpSpawnList)
        {
            pickUpSpawnStruct.PickupScpObj.PickupPooler.InitializePool(pickUpSpawnStruct.PickupScpObj.PickupPrefab, this.transform.position + pickupSpawnHeight);
            totalPickupSpawnRate += pickUpSpawnStruct.SpawnRate;
        }
    }

    /// <summary>
    /// Spawn Entity and spawn pickup on entity if it can support PickUp, based on SpawnList ScriptableObject.
    /// The distance between each Entity spawned is adjustable in the SpawnList ScriptableObject.
    /// </summary>
    void Update()
    {
        //Only able to spawn after the random interval has passed 
        if (isEntitySpawnable == true)
        {
            Entity newEntity;
            
            //generate random entity in the list
            newEntity = getRandomEntityScpObj();

            if (newEntity != null)
            {
                Debug.Log("===Spawning new GameObj instance from pool===");
                isPickUpSpawnable = newEntity.AllowPickUp;
                
                //Activate the returned inactive instance of the entity from its pooler
                GameObject spawnEntity = newEntity.EntityPooler.GetObject(gameObject.transform.position);
                spawnEntity.SetActive(true);
                
                if (isPickUpSpawnable)
                {
                    Pickup newPickup = getRandomPickupScpObj();
                
                    if (newPickup != null)
                    {
                        GameObject spawnPickup = newPickup.PickupPooler.GetObject(gameObject.transform.position + pickupSpawnHeight);
                        spawnPickup.transform.parent = spawnEntity.transform;
                        spawnPickup.SetActive(true);
                    }
                }
            }
            
            //Determines the random spawning interval
            StartCoroutine(EntitySpawnTimer());
        }
    }
    #endregion

    /// <summary>
    /// Get a random Entity tag from the SpawnList ScriptableObject
    /// </summary>
    /// <returns>Random Entity tag</returns>
    private Entity getRandomEntityScpObj()
    {
        float randomNo = Random.Range(0f , totalEntitySpawnRate);

        float currentSpawnRateQuotient = 0.0f;
        
        foreach (SpawnerList.EntitySpawnStruct spawnStruct in  SpawnerList.EntitySpawnList)
        {
            currentSpawnRateQuotient += spawnStruct.SpawnRate;
            
            if (spawnStruct.SpawnRate != 0.0f && randomNo <= currentSpawnRateQuotient)
            {
                return spawnStruct.EntityScpObj;
            }
        }
        
        return null;
    }
    
    /// <summary>
    /// Get a random Pickup from the SpawnList ScriptableObject
    /// </summary>
    /// <returns>Random PickUp</returns>
    private Pickup getRandomPickupScpObj()
    {
        float randomNo = Random.Range(0f , totalPickupSpawnRate);

        float currentSpawnRateQuotient = 0.0f;
        
        foreach (SpawnerList.PickUpSpawnStruct pickUpSpawnStruct in  SpawnerList.PickUpSpawnList)
        {
            currentSpawnRateQuotient += pickUpSpawnStruct.SpawnRate;
            
            if (pickUpSpawnStruct.SpawnRate != 0.0f && randomNo <= currentSpawnRateQuotient)
            {
                return pickUpSpawnStruct.PickupScpObj;
            }
        }
        
        return null;
    }
    
    /// <summary>
    /// Control the distance between each Entity spawned, adjustable in the SpawnList ScriptableObject.
    /// Used to prevent multiple consecutive entity spawns before enough space to spawn another entity
    /// </summary>
    /// <returns>Duration of non-spawnable time</returns>
    private IEnumerator EntitySpawnTimer() {
        isEntitySpawnable = false;
        
        float randomSec = Random.Range(MinSpawnInterval, MaxSpawnInterval);
        yield return new WaitForSeconds(randomSec);
        
        isEntitySpawnable = true;
    }
}
