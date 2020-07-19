using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Obstacle pooling

public class GenerateObstacle : MonoBehaviour {

    private float z = 60f;
    public string tag;

    [System.Serializable]
    public class Pool {
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static GenerateObstacle Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public Dictionary<string, Queue<GameObject>> poolObstacleDictionary;
    
    public List<Pool> poolOfObstacle;

    // At the very beginning, the obstacles are deactivated

    //Na samom startu generišu se prepreke deaktivirane

    void Start () {

        poolObstacleDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach (Pool obstacle in poolOfObstacle)
        {

            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < obstacle.size; i++)
            {
                GameObject obj = Instantiate(obstacle.prefab);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }

            poolObstacleDictionary.Add(tag, objectsPool);
        }

        

    }
    
    // The method that is called is activated by obstacles in a particular position

    //Metoda koja kad se pozove aktivira prepreke na određenoj poziciji

    public GameObject SpawnFromPoolObstacle(string tag, Vector3 position, Quaternion rotation) {

        if (!poolObstacleDictionary.ContainsKey(tag))
        {
            Debug.Log("pool with tag " + tag + " doesn't excist");
            return null;
        }

        GameObject objectToSpawn = poolObstacleDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolObstacleDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    // The method that invokes deactivates obstacles

    //Metoda koja kad se pozove deaktivira prepreke

    public GameObject RestartTheGame()
    {
        GameObject objectToSpawn = poolObstacleDictionary[tag].Dequeue();

        objectToSpawn.SetActive(false);

        poolObstacleDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }

}
