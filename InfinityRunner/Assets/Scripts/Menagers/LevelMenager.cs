using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script serves to communicate with the UI panel

//Skripta služi da komunicira sa UI panela

public class LevelMenager : MonoBehaviour {

    public GameObject platform;
    public GameObject musicMenager;

    public GameObject player;
    public GameObject[] platforms;
    public GameObject score;
    public GameObject specialItem;

    GenerateGold restartGenerationGold;
    GenerateObstacle restartGenerationObstacle;

    void Start(){
        restartGenerationGold = GenerateGold.Instance;
        restartGenerationObstacle = GenerateObstacle.Instance;
    }
    //Pause the game

    //Pauzira se igra
    public void PuseTheGame() {
        Time.timeScale = 0.0f;
    }
    
    // The game continues

    //Igra se nastavlja
    public void ContinueTheGame() {
        Time.timeScale = 1.0f;
    }

    // The game restarts as well as all objects in it

    //Restartuje se igra kao i svi objekti u njoj
    public void RestartTheGame() {
        for (int i = 0; i < 6; i++) {
            restartGenerationGold.RestartTheGame();
        }
        for (int i = 0; i < 3; i++)
        {
            restartGenerationObstacle.RestartTheGame();
        }
        specialItem.SetActive(false);
        player.transform.position = player.gameObject.GetComponent<PlayerControll>().startPosition;
        player.GetComponent<PlayerMove>().moveSpeed = 15;
        score.GetComponent<Score>().ResetScore();
        platforms[0].transform.position = new Vector3(0, -1.3f, 60f);
        platforms[1].transform.position = new Vector3(0, -1.3f, 120f);
        platforms[2].transform.position = new Vector3(0, -1.3f, 180f);
        platform.SetActive(true);
        
    }

    // When a player wants to return from the game to the home menu

    //Kada igrač želi da se vrati iz igre na početni meni
    public void BackFromTheGame() {
        RestartTheGame();
        player.gameObject.SetActive(false);
    }

    // When a player wants to get out of the whole game

    //Kada igrač želi da izađe iz cele igre
    public void QuitTheGame(){
        Application.Quit();
    }

    // Controller that moves the platform when a player exits from it

    //Kontroler koje pomera platformu kada igrač izađe iz nje
    public void PlatformControler(GameObject platform){
        platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z + 180f);
    }

    // In the scene, there are 4 platforms 3 that are used in a further game, but one just goes out and stays there

    //U sceni postoje 4 platforme 3 koje se koriste u daljoj igri ali jedna se samo gasi i ostaje tu
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Ball")) {
            platform.SetActive(false);
        }
    }


}
