using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SphereRotation : MonoBehaviour {

    public GameObject inGameMenu;
    public GameObject explosion;
    public LevelMenager lvlMenager;
    public AudioSource explosionSound;

    void Start(){

    }
    // The ball rotation script

    //Skripta za rotaciju lopte
    void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * 300f);

    }

    // When a ball hits a bump if it has a certain speed then it can destroy it where it causes the explosion and returns to the initial speed, otherwise it is the end of the game

    //Kada lopta udari u prepeku ako ima određenu brzinu onda može da je uništi gde i izaziva esplozija i vraća se na početnu brzinu, u suprotnom je kraj igre
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle")) {
            if (gameObject.transform.parent.GetComponent<PlayerMove>().moveSpeed >= 30){
                Vector3 pos = other.transform.position;
                Instantiate(explosion, pos, Quaternion.identity);
                explosionSound.Play();
                other.gameObject.SetActive(false);
                gameObject.transform.parent.GetComponent<PlayerMove>().moveSpeed = 15;
                gameObject.transform.parent.GetComponent<PlayerMove>().activator = false;
            }
            else {
                lvlMenager.GetComponent<LevelMenager>().PuseTheGame();
                inGameMenu.SetActive(true);
                
            }
        }
        
    }

    


}
