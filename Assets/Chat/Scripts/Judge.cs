using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

[Serializable]
public class Answer
{
    public int character;
    public int time;
    public int place;
    public int crime;
}

[Serializable]
public class AnswerList
{
    public List<Answer> answers;
}

public class Judge : MonoBehaviour
{
    public TMP_Dropdown cCharacter;
    public TMP_Dropdown cTime;
    public TMP_Dropdown cPlace;
    public TMP_Dropdown cCrime;
    public GameObject judgeCanvas;

    [SerializeField] public List<Answer> answers;

    public void StartJudge()
    {
        judgeCanvas.SetActive(true);
    }
    public bool CheckAnswer(int character, int time, int place, int crime)
    {
        foreach (Answer answer in answers)
        {
            if(character == answer.character && time == answer.time && place == answer.place && crime == answer.crime)
            {
                return true;
            }
            //Debug.Log(answer.character);
            //Debug.Log(answer.time);
            //Debug.Log(answer.place);
            //Debug.Log(answer.crime);
        }
        return false;
    }

    public void FinishJdge()
    {
        judgeCanvas.SetActive(false);

        if (CheckAnswer(cCharacter.value, cTime.value, cPlace.value, cCrime.value))
        {
            Debug.Log("�����ȷ");
        }
        else
        {
            Debug.Log("��ڴ���");
        }

    }
    void Start()
    {
        string path = Application.dataPath + "/InerData/Answer.json";
        string jsontext = File.ReadAllText(path);
        AnswerList answerList = JsonUtility.FromJson<AnswerList>(jsontext);
        answers = answerList.answers;

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            FinishJdge();
        }
    }
}
