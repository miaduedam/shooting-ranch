using UnityEngine;
using System.Linq;
using TMPro;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreBoardText;
    private List<float> bestTimes = new List<float>();
    private float latestTime = -1f;

    private void Start()
    {
        UpdateBoard();
          
    }

    public void AddNewTime(float newTime)
    {
        latestTime = newTime;

        bestTimes.Add(newTime);
        bestTimes = bestTimes.OrderBy(time => time).Take(3).ToList();
        
        UpdateBoard();
    }

    private void UpdateBoard()
    {
        string text = "BARN RECORDS\n\n";

        for(int i = 0; i < 3; i++)
        {
            if(i < bestTimes.Count)
            {
                text += $"{i + 1}. {bestTimes[i]:F2}s\n";
            }
            else
            {
            text += $"{i + 1}. --.--s\n";
            }
        }
        
        text += "\nLATEST\n";

            if (latestTime >= 0)
            {
                text += $"{latestTime:F2}s";
            }
            else
            {
                text += "--.--s";
            }

            scoreBoardText.text = text;
    }

}
