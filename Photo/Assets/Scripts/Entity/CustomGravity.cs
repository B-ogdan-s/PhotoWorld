using System;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GravitiInfo _gravitiInfo;
    [SerializeField, Min(0.1f)] private float _gravityScaler;
    
    private const float _gravity = -9.81f;

    [SerializeField] private float _speed = 0;
    private bool _isGround = false;

    public bool IsGround => _isGround;

    private void FixedUpdate()
    {
        CheckGroundRay();
    }

    private void CheckGroundRay()
    {
        Ray ray = new Ray(_gravitiInfo.StartPos.position, Vector3.down);
        
        if(_characterController.isGrounded)
        {
            if (!_isGround)
            {
                _speed = 0;
                _isGround = true;
            }
            return;
        }
        if(Physics.Raycast(ray, out RaycastHit hit, _gravitiInfo.CheckHeightDistans, _gravitiInfo.LayerMask))
        {   
            if (!_isGround)
            {
                _speed = 0;
                transform.position = hit.point + Vector3.up * _gravitiInfo.HeightDistans;
                _isGround = true;
            }
            return;
        }
        _isGround = false;
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        _speed += _gravity * Time.fixedDeltaTime * _gravityScaler;
        _characterController.Move(Vector3.up * _speed * Time.fixedDeltaTime);
    }

    public void SetGravitySpeed(float value)
    {
        _speed = value;
        ApplyGravity();
    }

    [Serializable]
    private class GravitiInfo
    {
        [SerializeField] private float _heightDistans;
        [SerializeField] private float _checkHeightDistans;
        [SerializeField] private Transform _startPos;
        [SerializeField] private LayerMask _layerMask;

        public float HeightDistans => _heightDistans;
        public float CheckHeightDistans => _checkHeightDistans;
        public Transform StartPos => _startPos;
        public LayerMask LayerMask => _layerMask;
    }
}
