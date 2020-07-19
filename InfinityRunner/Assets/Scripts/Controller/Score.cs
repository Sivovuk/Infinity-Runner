using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The script serves to track results and periodically change the text displayed on the screen when touching the edges of the player

//Skripta služi za praćenje rezultata i periodično promene u tekstu koji se prikazuje na ekranu kada dođe do dodira ivica sa igracem

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreText;
    

	void Start () {
		
	}
	
	void Update () {
		
	}

   //Ako dodje do dodira igraca sa zlatnicima oni se gase a rezultat se povećava. Takođe se i poziva zvuk zveckanja novčića

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Gold")) {
            other.gameObject.SetActive(false);
            score++;
            scoreText.text = "Score : " + score;
            GameObject music = GameObject.Find("MusicMenager");
            music.GetComponent<MusicMenager>().GoldCoinCollecting();
            //Debug.Log(score);
        }
        
    }

    //funkcija služi samo da resetuje skor kada se pozove

    public void ResetScore() {
        score = 0;
        scoreText.text = "Score : " + score;
    }

}
