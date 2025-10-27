using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private GameObject restartbutton;
    [SerializeField] private GameObject usualScreen;
    [SerializeField] private GameObject victoryCamera;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject sliderRed;
    [SerializeField] private GameObject sliderGreen;
    [SerializeField] private GameObject sliderBlue;
    public void ShowRestartButton()
    {
        usualScreen.SetActive(false);
        restartbutton.SetActive(true);
        audioSource.GetComponent<audioLoop>().winAudioChange();
        playerTransform.gameObject.GetComponent<mouvement>().setPlayerWin();
    }
    public void HideRestartButton()
    {
        restartbutton.SetActive(false);
        usualScreen.SetActive(true);
    }
    public void RestartGame()
    {
        HideRestartButton();
        victoryCamera.SetActive(false);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        Debug.Log(coins.Length);
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
            coins[i].GetComponent<MeshRenderer>().enabled = true;
            coins[i].GetComponent<Collider>().enabled = true;
        }
        audioSource.GetComponent<audioLoop>().mainAudioChange();
        playerTransform.gameObject.GetComponent<mouvement>().setPlayerReset();
        playerTransform.position = new Vector3(0, 2, 0);
        playerTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerTransform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    void Start()
    {
        RestartGame();
    }
    void Update()
    {
        Color color = new Color(sliderRed.GetComponent<Slider>().value, sliderGreen.GetComponent<Slider>().value, sliderBlue.GetComponent<Slider>().value);
        playerTransform.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", color);
    }
}
