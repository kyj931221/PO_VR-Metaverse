using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    GameObject player;

    public override void OnJoinedRoom()
    {
        // 룸에 접속하면 플레이어를 정해진 위치에 생성
        base.OnJoinedRoom();
        player = PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        // 룸을 나가면 플레이어를 삭제
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }
}
