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

using UnityEngine;

/// <summary>
/// Disable the GameObject when collided with invisible wall
/// </summary>
public class EntityCollision : MonoBehaviour
{
    /// <summary>
    /// Default Parent to return to when object get deactivated.
    /// </summary>
    [Tooltip("Default Parent to return to when object get deactivated.")]
    public Transform DefaultParent;

    #region MonoBehaviour Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground")
        {
            //Detach child/ PickUp from its parent
            if ( other.gameObject.transform.childCount > 0)
            {
                GameObject childObj =  other.gameObject.transform.GetChild(0).gameObject;
                childObj.transform.parent = DefaultParent;
                childObj.SetActive(false);
            }
            
            other.gameObject.SetActive(false);
        }
    }
    #endregion
}
