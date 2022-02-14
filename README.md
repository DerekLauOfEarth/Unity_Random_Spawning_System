# Unity_Random_Spawning_System #
A 3D random spawning system inspired by Frogger, written based on Unity's ScriptableObject Game Architecture.  
Entity GameObject represents moving log/ car in Frogger, while Pickup GameObject represents coin/ power-up in Frogger.  

The random spawning system will spawns instances of entities within random interval/ distance, then based on its associated entity ScriptableObject value, further determining whether a pickup will spawn above said entity.  
The spawned instances will keep on moving from right to left until they hit a invisible wall and get despawned/ deactivated or get "returned" to the object pooler.  
 
The system is written based on game architecture and technique below:
1. ScriptableObject
2. ObjectPooling
3. Coding Style Guideline



 ## ScriptableObject ##
The ScriptableObjects modularly controls most aspects of the system:
 - Entity and Pickup Prefabs and their associated ObjectPoolers
 - Entity and Pickup spawning rate and movement speed
 - ObjectPooler's size and behaviour (whether pooler size expansion beyond initial is allowed)
 - Entity's support for Pickup spawning
 
 
Within this example, there will be 2 type of Entities, Cube and Sphere, and 2 types of Pickups, Capsule and Cylinder.  
Below are their spawn rates and associated behaviours which are all specified within multiple ScriptableObjects.

Entities:
- Cube
  - Spawn rate = 0.8
  - Supports Pickup spawning
- Sphere
  - Spawn rate = 0.2
  - Doesn't support Pickup spawning

Pickups:
- Capsule
  - Spawn rate = 0.75
- Cylinder
  - Spawn rate = 0.25



## ObjectPooling ##
Entities and Pickups will be spawned from their respective poolers with their initial size determined within their ScriptableObject.  
Whenever the random spawning system is spawning a new GameObject, it will receive a valid entry from the ObjectPooler list of gameobject by checking whether said GameObject entry is active in the Game Editor hierarchy.  

If all ObjectPooler entries are currently active in the Game Editor hierarchy and the ObjectPooler's ScriptableObject setting allows size expansion, a new GameObject entry will be created, added to the ObjectPooler list of GameObjects and finally spawned.



## Coding Style Guidline ##
The code is written based on an external coding style guideline and aptly commented throughtout the code.  

Extra Unity Inspector UI elements, such as tooltip and list, are written to provide readability and for less technical-oriented users' ease of understanding.  
Prime example will be the SpawnerList.cs / SpawnerList ScriptableObject.
