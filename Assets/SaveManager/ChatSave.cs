using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static ChatSave;

public class ChatSave : MonoBehaviour
{
    [Serializable]
    public class ChatData
    {
        public int sTime;
        public List<string> qMessages;
        public List<string> aMessages;
    }
    public ChatData mChatData = new ChatData();

    public static int stTime;

    public void SaveChat()
    {

        string filePath = Application.persistentDataPath + "/chatdata.json";
        mChatData.sTime = Chat.saintTime;
        mChatData.qMessages = GetHistory.hQuestion;
        mChatData.aMessages = GetHistory.hAnswer;
        string jsonStr = JsonUtility.ToJson(mChatData);
        File.WriteAllText(filePath, jsonStr);
    }

    public void LoadChat()
    {
        string filePath = Application.persistentDataPath + "/chatdata.json";
        Debug.Log(Chat.saintTime);
        if (File.Exists(filePath))
        {
            string jsonStr = File.ReadAllText(filePath);
            ChatData nChatData = JsonUtility.FromJson<ChatData>(jsonStr);
            stTime = nChatData.sTime;
            GetHistory.hQuestion = nChatData.qMessages;
            GetHistory.hAnswer = nChatData.aMessages;
            Debug.Log(Chat.saintTime);
        }
        else
        {
            stTime = 0;
            GetHistory.hQuestion.Clear();
            GetHistory.hAnswer.Clear();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
