using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 offset = new(0, 15, -15);
    [SerializeField] Camera cam;
    [SerializeField] Transform playerTransform;

    void Awake()
    {
        cam = GetComponent<Camera>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = playerTransform.position + offset;
        cam.transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = playerTransform.position + offset;
        cam.transform.position = targetPosition;
    }
}
