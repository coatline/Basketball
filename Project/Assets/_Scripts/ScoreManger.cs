using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour
{
    static ScoreManger instance;

    public static ScoreManger Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("No Score instance found! Creating one.");
                GameObject gob = new GameObject("Score");
                instance = gob.AddComponent<ScoreManger>();
            }
            return instance;
        }
    }

    void OnEnable()
    {
        if (instance == null)
            instance = this;
    }

    public RectTransform textTarget;
    public RectTransform scorePlace;
    public Transform playerPosition;
    public Text shotsAmount;
    public Text shotPercentage;
    public Text scoreText;
    public Rigidbody ballRb;
    public int pointer = 2;
    int threePointers = 0;

    int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateStats();
        }
    }

    int shotsTaken = 0;
    public int ShotsTaken
    {
        get { return shotsTaken; }
        set
        {
            shotsTaken = value;
            UpdateStats();
        }
    }

    private void UpdateStats()
    {
        float percentage = 0;
        if (shotsTaken != 0)
            percentage = (score / 2) / (float)shotsTaken;
        percentage *= 100;

        int evenStuff  = 0;

        //this is bad practice 
        // probably should change it

        switch (threePointers) {
            case 2:
                evenStuff = 1;
                break;
            case 3:
                evenStuff = 1;
                break;
            case 4:
                evenStuff = 2;
                break;
            case 5:
                evenStuff = 2;
                break;
            case 6:
                evenStuff = 3;
                break;
            case 7:
                evenStuff = 3;
                break;
            case 8:
                evenStuff = 4;
                break;
            case 9:
                evenStuff = 4;
                break;
            case 10:
                evenStuff = 5;
                break;
            case 11:
                evenStuff = 5;
                break;
            case 12:
                evenStuff = 6;
                break;
            case 14:
                evenStuff = 7;
                break;
            default:
                evenStuff = 0;
                break;
        }

        

        scoreText.text = "Score: " + score;

        // made/shots
        shotsAmount.text = "accuracy: " + (score / 2 - evenStuff) + "/" + shotsTaken;

        // percentage
        shotPercentage.text = "percentage: " + percentage.ToString("#.##") + "%";
    }


    void Update()
    {
        if (scorePlace != null)
        {
            scorePlace.transform.position = playerPosition.position + Vector3.up * 1.6f;
        }

        if (Shoot.threePointer)
        {
            pointer = 3;
        }
        else
        {
            pointer = 2;
        }

        if (textTarget != null)
            textTarget.transform.position = playerPosition.position + Vector3.up * 1;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("IDK") && ballRb.velocity.y < 0)
        {
            if(pointer == 3)
            {
                threePointers++;
            }
            Score += pointer;
        }
    }
}
