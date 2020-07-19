using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gold pooling

public class GenerateGold : MonoBehaviour {
    
    public string tag;

    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static GenerateGold Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Dictionary<string, Queue<GameObject>> poolGoldDictionary;

    public List<Pool> poolOfGold;

    // At the very beginning gold is deactivated

    //Na samom startu generišu se zlato deaktivirane

    void Start()
    {

        poolGoldDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach (Pool gold in poolOfGold)
        {

            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < gold.size; i++)
            {
                GameObject obj = Instantiate(gold.prefab);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }

            poolGoldDictionary.Add(tag, objectsPool);
        }



    }
    // The method that is called is activated by obstacles in a particular position

    //Metoda koja kad se pozove aktivira prepreke na određenoj poziciji

    public GameObject SpawnFromPoolObstacle(string tag, Vector3 position, Quaternion rotation)
    {

        if (!poolGoldDictionary.ContainsKey(tag))
        {
            Debug.Log("pool with tag " + tag + " doesn't excist");
            return null;
        }

        GameObject objectToSpawn = poolGoldDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolGoldDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    // The method that invokes deactivates obstacles

    //Metoda koja kad se pozove deaktivira prepreke

    public GameObject RestartTheGame() {
        GameObject objectToSpawn = poolGoldDictionary[tag].Dequeue();

        objectToSpawn.SetActive(false);

        poolGoldDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }

}
