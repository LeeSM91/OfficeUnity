using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    Vector3 _delta;

    [SerializeField]
    GameObject _player;

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            Vector3 dir = transform.position;
            dir.x = _player.transform.position.x + _delta.x;
            dir.z = _player.transform.position.z + _delta.z;
            transform.position = dir;
        }
    }
}
