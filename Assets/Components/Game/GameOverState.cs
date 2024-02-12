using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject GameOver;

    private void Update()
    {
        if (player == null)
            GameOver.SetActive(true);
    }
}
