using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private float endPosition = 6f;

    private void Start()
    {
        startPosition = transform.position;

        transform.DOMoveZ(transform.position.z + this.endPosition, 2).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(270f, 155.085999f, 35f), .1f).SetLoops(-1, LoopType.Incremental);
    }
}
