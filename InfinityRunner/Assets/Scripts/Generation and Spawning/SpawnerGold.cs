using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script serves to activate the gold coins and place them on the path

//Skripta služi da aktivira zlatne novčiće i postavi ih na putanji

public class SpawnerGold : MonoBehaviour {

    public GameObject[] planes;

    GenerateGold objectPooler;

    public string tag;

    void Start()
    {
        objectPooler = GenerateGold.Instance;
    }

    // A method that pulls coins from the pool and activates them on free paths

    //Metoda koja povlači zlatnike iz pool-a i aktivira ih na slobodnim putanjama
    public void ObjSpawner()
    {
        for (int i = 0; i < 9; i++) {
            if (planes[i].GetComponent<PlaneController>().tracker == false) {
                Vector3 position = new Vector3(planes[i].transform.position.x, planes[i].transform.position.y + 1, planes[i].transform.position.z);
                objectPooler.SpawnFromPoolObstacle(tag, position, Quaternion.identity);
            }
        }
    }
    // When a player passes through the chess-boards, the method above is called

    //Kada igrač prođe kroz colajdere poziva se metoda iznad
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Ball"))
        {
            ObjSpawner();
        }
    }
}
