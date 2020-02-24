using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //private Transform entryContainer;
    //private Transform entryTemplate;
    //private List<Transform> highscoreEntryTransformList;

    //private void Awake()
    //{
    //    entryContainer = transform.Find("highscoreEntryContainer");
    //    entryTemplate = entryContainer.Find("highscoreEntryTemplate");

    //    entryTemplate.gameObject.SetActive(false);

    //    string jsonString = PlayerPrefs.GetString("MainMenuPanel");
    //    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    //    for (int i = 0; highscores.highscoreEntryList; i++)
    //    {
    //        for(int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
    //        {
    //            if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
    //            {
    //                HighscoreEntry tmp = highscores.highscoreEntryList[i];
    //                highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
    //                highscores.highscoreEntryList[j] = tmp;
    //            }
    //        }
    //    }

    //    highscoreEntryTransformList = newList<Transform>();
    //    foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
    //    {
    //        CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
    //    }

    //}

    //private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    //{
    //    float templateHeight = 20f;
    //    Transform entryTransform = Instantiate(entryTemplate, container);
    //    RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
    //    entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
    //    entryTransform.gameObject.SetActive(true);

    //    int rank = transformList.Count + 1;
    //    string rankString;
    //    switch (rank)
    //    {
    //        default:
    //            rankString = rank + "TH"; break;
    //        case 1: rankString = "1ST"; break;
    //        case 2: rankString = "2ND"; break;
    //        case 3: rankString = "3RD"; break;
    //    }

    //    int score = highscoreEntry.score;
    //    entryTransform.Find("posText").GetComponent<Text>().text = rankString;
    //    entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
    //    string name = highscoreEntry.name;
    //    entryTransform.Find("nameText").GetComponent<Text>().text = name;


    //    transformList.Add(entryTransform);
    //}

    //private void AddHighscoreEntry(int score, string name)
    //{
    //    HighscoreEntry highscoreEntry = new HighscoreEntry {score = score, name = name};
    //}

    //private class HighscoreEntry
    //{
    //    public int score;
    //    public string name;
    //}

}
