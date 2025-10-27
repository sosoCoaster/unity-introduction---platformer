using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().enabled = true;
        this.GetComponent<AudioSource>().time = 0.4f;
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<AudioSource>().time > 4.5f)
        {
            Destroy(this);
        }
    }
}
