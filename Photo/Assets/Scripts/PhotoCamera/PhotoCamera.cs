using UnityEngine;

public class PhotoCamera : MonoBehaviour
{
    [SerializeField] private PhotoCameraAnimation _photoCameraAnimation;
    private bool _isOpenCamera = false;
    public void OpenOrClosePhotoCamera()
    {
        if (_isOpenCamera)
            _photoCameraAnimation.Close();
        else
            _photoCameraAnimation.Open();

        _isOpenCamera = !_isOpenCamera;
    }
}
