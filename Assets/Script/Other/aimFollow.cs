using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimFollow : MonoBehaviour
{
    [Header("Position Component")]
    private Transform _thisChild;
    private Vector3 _positionOffset;
    private Quaternion _rotationOffset;

    [Header("Reference")]
    public Transform fakeParent;
    private playerMove _playerMove;

    private void Awake()
    {
        _playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
    }

    private void Start()
    {
        _thisChild = this.transform;

        if (fakeParent != null)
        {
            SetFakeParent(fakeParent);
        }


    }

    private void Update()
    {
        Debug.Log(_playerMove.playerDirection + " : ");
        
        if (fakeParent == null)
        {
            return;
        }

        // Position the object on top of the parent
        _thisChild.position = fakeParent.position;
        // Set the rotation based on the parent and stored offset rotation
        _thisChild.rotation = fakeParent.rotation * _rotationOffset;
        // Move the child back to the reference location
        _thisChild.Translate(_positionOffset);
    }

    public void SetFakeParent(Transform parent)
    {
        //Offset vector
        _positionOffset = _thisChild.InverseTransformPoint(_thisChild.position) - _thisChild.InverseTransformPoint(parent.position);
        //Offset rotation
        _rotationOffset = Quaternion.Inverse(parent.rotation) * transform.rotation;
        //Our fake parent
        fakeParent = parent;
    }

    public void AimPosition()
    {
        if (true)
        {
            //_playerMove.playerDirection !=
        }
    }
}
