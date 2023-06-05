using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_History : MonoBehaviour
{
    public GameObject uiObject;

    private void Start()
    {
        // Desativa o objeto de UI no início do jogo
        uiObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ativa o objeto de UI quando o jogador colide
            uiObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desativa o objeto de UI quando o jogador sai da colisão
            uiObject.SetActive(false);
        }
    }
}
