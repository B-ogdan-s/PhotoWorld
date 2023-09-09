using System;
using UnityEngine;

[Serializable]
public class PlayerComponentData
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerJump _playerJump;

    public PlayerMove PlayerMove => _playerMove;
    public PlayerJump PlayerJump => _playerJump;

}
