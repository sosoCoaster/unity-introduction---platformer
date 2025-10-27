using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelEnd : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineVirtualCamera victoryCamera;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Canvas canvas;
    private void OnTriggerEnter(Collider other)
    {
        victoryCamera.LookAt = playerTransform;
        victoryCamera.gameObject.SetActive(true);
        canvas.GetComponent<CanvasUI>().ShowRestartButton();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
