using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script serves to control the player

//Skripta služi kontrolisanje igrača

public class PlayerControll : MonoBehaviour {

    public Vector3 startPosition;

    private Vector3 mousePosition;
    private Vector3 playerPosition;
    public GameObject player;

    private bool positionTrackerRight;
    private bool positionTrackerLeft;

    //Player lerp

    private Vector3 startPos;
    private Vector3 endPos;
    private float distance;

    private float lerpTime = 0.5f;
    private float currTime = 0;
    private bool positionCheck = false;

    void Start()
    {
        startPosition = gameObject.transform.position;
        startPos = player.transform.localPosition;
        endPos = player.transform.localPosition + Vector3.up * distance;
    }

    void Update()
    {
        // The player moves to a specific page defined in the method below

        //Izvršava se pomeranje igraca u odredjenu stranu koja je definisane u metodi ispod
        if (positionCheck == true)
        {
            currTime += Time.deltaTime;
            if (currTime >= lerpTime)
            {
                currTime = lerpTime;
            }

            float Perc = currTime / lerpTime;
            player.transform.localPosition = Vector3.Lerp(startPos, endPos, Perc);
        }

    }
    // The mouse position is clicked when it clicks

    //Uzima se pozicija miša kada se klikne
    void OnMouseDown()
    {
        mousePosition = Input.mousePosition;
        
    }
    // Two positions are compared to determine which side of the player wants to move left or right

    //Uporedjuju se dve pozicije da bi se utvrdilo na koju stranu igrač želi da se pomeri levo ili desno
    void OnMouseUp()
    {
        
        //Levo /Left
        if (mousePosition.x > Input.mousePosition.x )
        {
            if (positionTrackerLeft == false && positionTrackerRight == false) {
                playerPosition = new Vector3(-2f, player.transform.localPosition.y, player.transform.localPosition.z);
                Lerp(player.transform.localPosition, playerPosition, 20f);
                positionTrackerLeft = true;
                currTime = 0;
            }
            else if (positionTrackerLeft == false && positionTrackerRight == true) {
                playerPosition = new Vector3(0, player.transform.localPosition.y, player.transform.localPosition.z);
                Lerp(player.transform.localPosition, playerPosition, 20f);
                positionTrackerRight = false;
                currTime = 0;
            }
        }

        //Desno /Right
        else if (mousePosition.x < Input.mousePosition.x )
        {
            if (positionTrackerRight == false && positionTrackerLeft == false) {
                playerPosition = new Vector3(2f, player.transform.localPosition.y, player.transform.localPosition.z); 
                Lerp( player.transform.localPosition, playerPosition, 20f);
                positionTrackerRight = true;
                currTime = 0;

            }
            else if (positionTrackerRight == false && positionTrackerLeft == true) {
                playerPosition = new Vector3(0, player.transform.localPosition.y, player.transform.localPosition.z); ;
                Lerp(player.transform.localPosition, playerPosition, 20f);
                positionTrackerLeft = false;
                currTime = 0;
            }
        }
        
    }
    // The function is used to set the player's positions and activate the move

    //Funkcija služi za namestanje pozicija igraca i aktiviranje pomeranja
    public void Lerp(Vector3 startPosition, Vector3 endPosition, float distance)
    {

        startPos = startPosition;
        endPos = endPosition;
        distance = this.distance;
        positionCheck = true;
    }

}
