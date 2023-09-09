using System;
using UnityEngine;

[Serializable]
public class PlayerJump
{
    [SerializeField] private CustomGravity _customGravity;
    [SerializeField] private float _jumpF;

    public void Jump()
    {
        Debug.Log(_customGravity.IsGround);
        if(_customGravity.IsGround)
            _customGravity.SetGravitySpeed(_jumpF);
    }
}
