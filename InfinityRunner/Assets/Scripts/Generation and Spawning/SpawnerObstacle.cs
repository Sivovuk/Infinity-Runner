using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script serves to activate obstacles on the path as well as quitting when they are no longer needed

//Skripta služi za aktiviranje prepreka na putanju kao i gašenje kada više nisu potrebne

public class SpawnerObstacle : MonoBehaviour {

    public GameObject[] planes;
    
    GenerateObstacle objectPooler;

    public string tag;


    void Start()
    {
        objectPooler = GenerateObstacle.Instance;
    }

    private void Update()
    {
        
    }
    // A function that pulls an obstruction from the pool and puts them on the path

    //Funkcija koja povlači prepreku iz pool-a i postavlja ih na putanji
    public void ObjSpawner () {
        
        int random1 = Random.Range(0,3);
        int random2 = Random.Range(3, 6);
        int random3 = Random.Range(6, 9);

        objectPooler.SpawnFromPoolObstacle(tag, planes[random1].transform.position, Quaternion.identity);
        planes[random1].GetComponent<PlaneController>().tracker = true;
        objectPooler.SpawnFromPoolObstacle(tag, planes[random2].transform.position, Quaternion.identity);
        planes[random2].GetComponent<PlaneController>().tracker = true;
        objectPooler.SpawnFromPoolObstacle(tag, planes[random3].transform.position, Quaternion.identity);
        planes[random3].GetComponent<PlaneController>().tracker = true;

        StartCoroutine(planeTrackerSet(random1, random2, random3));

    }

    // When a player passes through an activator, he is activated and calls ObjSpawner ()

    //Kada igrač prođe kroz aktivator on se aktivira i poziva ObjSpawner()
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Ball"))
        {
            ObjSpawner();
        }
    }

    // After a certain time the paths are returned to the position from the beginning of the game to be used later

    //Posle određenog vremena putanje se vraćaju u poziciju sa početka igre da bi se koristili i kasnije
    public IEnumerator planeTrackerSet(int random1, int random2, int random3) {
        yield return new WaitForSeconds(1);
        planes[random1].GetComponent<PlaneController>().tracker = false;
        planes[random2].GetComponent<PlaneController>().tracker = false;
        planes[random3].GetComponent<PlaneController>().tracker = false;
    }

    

}
