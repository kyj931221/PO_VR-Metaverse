using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;

public class VRChat : MonoBehaviour
{
    public Image backUI;

    List<string> list;
    public Text[] text;
    public InputField chat;

    PhotonView pv;
    
    void Start()
    {
        pv = GetComponent<PhotonView>();
        list = new List<string>();
    }

    public void SendTalk()
    {
        string str = PhotonNetwork.NickName + ": " + chat.text;
        pv.RPC("AddTalkRPC", RpcTarget.All, str);
        chat.text = "";
    }

    [PunRPC]
    void AddTalkRPC(string str)
    {
        while (list.Count >= 5)
        {
            list.RemoveAt(0);
        }

        list.Add(str);
        UpdateTalk();
    }

    void UpdateTalk()
    {
        for(int i = 0; i < list.Count; i++)
        {
            text[i].text = list[i];
        }
    }
}
