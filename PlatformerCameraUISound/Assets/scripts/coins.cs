using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class coins : MonoBehaviour
{
    // Start is called before the first frame update*
    [SerializeField] private float speedRotationPerSecond;
    [SerializeField] protected AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(audioSource,this.transform);
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    void Start()
    {
        this.transform.Rotate(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(speedRotationPerSecond * Time.deltaTime, 0f, 0f);
    }
}
