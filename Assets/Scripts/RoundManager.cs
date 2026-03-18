using System.Diagnostics;
using UnityEngine;


// start round, time, count targets, sent endtime to scoreboard

public class RoundManager : MonoBehaviour
{
private bool roundStarted = false;
private bool roundEnded = false;
private float roundTime = 0f;   
private int totalTargets = 0;
private int targetsHit = 0;

[SerializeField] ScoreBoard scoreBoard;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundStarted = false;
        roundEnded = false;
        roundTime = 0f;
        targetsHit = 0;
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        Debug.Log("Total targets: " + totalTargets);
    }

    // Update is called once per frame
    void Update()
    {
        if (roundStarted && !roundEnded)
        {
            roundTime += Time.deltaTime;
            
        }
    }


    public void StartRound()
    {
       if (!roundStarted && !roundEnded)
        {
            roundStarted = true;
            Debug.Log("Round started!");
        } else
        {
            Debug.Log("Cannot start round.");
        }
    }


    public void RegisterHit()
    {
        if (!roundStarted || roundEnded)
        {
            Debug.Log("Round is not active.");
            return;    
        }
            targetsHit++;
            Debug.Log("Target hit! Total hits: " + targetsHit + " Targets left: " + (totalTargets - targetsHit));
        
        if (targetsHit >= totalTargets)
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        if (roundStarted && !roundEnded)
        {
            roundEnded = true;
            Debug.Log("Round ended! Time: " + roundTime + " Targets hit: " + targetsHit);
            scoreBoard.AddNewTime(roundTime);
        }
    }
}