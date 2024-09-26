using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    GameObject player;

    public override void OnJoinedRoom()
    {
        // �뿡 �����ϸ� �÷��̾ ������ ��ġ�� ����
        base.OnJoinedRoom();
        player = PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        // ���� ������ �÷��̾ ����
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }
}
