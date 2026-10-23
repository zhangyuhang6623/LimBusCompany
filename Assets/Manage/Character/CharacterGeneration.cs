using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGeneration : MonoBehaviour
{
    public CharacterSelectEventSo player;
    private void Start()
    {
        if(player == null)return;
        Instantiate(player.player1);
        player.player1 = null;
    }
}
