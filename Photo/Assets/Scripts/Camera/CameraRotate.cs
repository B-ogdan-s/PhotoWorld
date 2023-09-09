using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _copiRotateObject;

    private void Update()
    {
        transform.localEulerAngles = Vector3.Scale(Vector3.right, _copiRotateObject.localEulerAngles);
    }
}
