using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class CameraParameters
{
    public float angleXZ = 45f;
    public float angleY = -90f;
    public float distance = 10f;
    public float speedOfMove = 25f;
    public float speedOfRotating = 25f;
    [HideInInspector] public Camera camera;
}

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    private Camera _camera;
    private Transform _target;

    [SerializeField]private CameraParameters _cameraParameters;


    public void Init(CameraParameters cameraParameters, Transform target)
    {
        _cameraParameters = cameraParameters;
        _camera = GetComponent<Camera>();
        SetTarget(target);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Update()
    {
        if (_target == null) return;
        Vector3 newPos = CulculateNewPose();

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, newPos, 0.1f * Time.deltaTime * _cameraParameters.speedOfMove);
        Quaternion targetRotation = Quaternion.LookRotation(_target.position - _camera.transform.position);
        transform.rotation = Quaternion.Slerp(_camera.transform.rotation, targetRotation, 0.1f * _cameraParameters.speedOfRotating * Time.deltaTime);
    }
    private Vector3 CulculateNewPose()
    {
        Vector3 newPos, targetPos;
        targetPos = _target.position;

        var deltaAngle = Mathf.Deg2Rad * (_cameraParameters.angleXZ);

        newPos.z = targetPos.z + _cameraParameters.distance * Mathf.Cos(deltaAngle);
        newPos.y = targetPos.y + _cameraParameters.distance * Mathf.Sin(deltaAngle);

        float newDistance = Mathf.Abs(newPos.z - targetPos.z);

        deltaAngle = Mathf.Deg2Rad * (270 - _cameraParameters.angleY);

        newPos.x = targetPos.x + newDistance * Mathf.Cos(deltaAngle);
        newPos.z = targetPos.z + newDistance * Mathf.Sin(deltaAngle);

        return newPos;
    }

    public void SetNewCameraAngle(float angleXZ, float angleY)
    {
        _cameraParameters.angleXZ = angleXZ;
        _cameraParameters.angleY = angleY;
    }
}
