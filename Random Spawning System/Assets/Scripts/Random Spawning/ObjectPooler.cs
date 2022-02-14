/* 
----- Identification -----
Date Created: 11/11/2021
Developer: Brandon
Date Last Updated: 14/02/2022
Last Update Dev: Derek
-----------------------------
*/

/* 
----- Change Log -----
v0.0.0 - Initial Script by Brandon
v0.0.1 - Modified by Derek to better suit this use case
            >Removed Irrelevant method
            >Modified behaviour of some methods
----------------------
*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectPooler : ScriptableObject
{
    /// <summary>
    /// Initial size of the object pool.
    /// </summary>
    [Tooltip("Initial size of the object pool.")]
    public int InitialPoolSize;

    /// <summary>
    /// Determine if the pool can grow in size during runtime.
    /// </summary>
    [Tooltip("If the pool fails to return an object, should it create " +
        "one and increase the pool's size accordingly?")]
    public bool CanGrow;

    /// <summary>
    /// Object pool list.
    /// </summary>
    private List<GameObject> objectPool;
    
    /// <summary>
    /// Prefeb object to be pooled
    /// </summary>
    private GameObject objectToPool;

    /// <summary>
    /// Returns the first inactive gameObject in the object pool. If the pool
    /// is allowed to grow, and this method fails to return an inactive
    /// gameObject, then a new object will be created, added to the pool, and 
    /// returned.
    /// </summary>
    /// <returns>{GameObject} First inactive object in pool, or newly added 
    /// gameObject if the pool is allowed to grow.</returns>
    public GameObject GetObject(Vector3 SpawnPosition)
    {
        foreach (GameObject gameObject in objectPool)
        {
            if (!gameObject.activeInHierarchy)
            {
                gameObject.transform.position = SpawnPosition;
                return gameObject;
            }
        }

        if (CanGrow)
        {
            GameObject gameObject;
            gameObject = InstantiatePoolObject(SpawnPosition);
            return gameObject;
        }

        return null;
    }

    /// <summary>
    /// Initialize object's pool which is populated with its assigned prefab.
    /// </summary>
    /// <param name="entityPrefab">Prefab to be pooled</param>
    /// <param name="SpawnPosition">Instance spawning position</param>
    public void InitializePool(GameObject entityPrefab, Vector3 SpawnPosition)
    {
        objectPool = new List<GameObject>();

        objectToPool = entityPrefab;
            
        for (int i = 0; i < InitialPoolSize; i++)
        {
            InstantiatePoolObject(SpawnPosition);
        }
    }

    /// <summary>
    /// Instantiated the objectToPool at the inputted spawn position
    /// </summary>
    /// <param name="SpawnPosition">Instance spawning position</param>
    private GameObject InstantiatePoolObject(Vector3 SpawnPosition)
    {
        GameObject gameObject;
        
        //Instantiated into Parent's GameObject (ScriptableObject doesn't accept reference to the editor gameobject hierarchy)
        gameObject = Instantiate(objectToPool, SpawnPosition, Quaternion.identity, GameObject.Find("ObjectPool").transform);

        gameObject.SetActive(false);
        objectPool.Add(gameObject);
        return gameObject;
    }
    
    /// <summary>
    /// Deactivates all objects in the object pool. Useful for resets.
    /// </summary>
    public void DeactivateAll()
    {
        foreach (GameObject gameObject in objectPool)
        {
            gameObject.SetActive(false);
        }
    }
}
