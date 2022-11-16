﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonCrawl
{
    public class MenuManager : MonoBehaviour
    {
        public int gameStartScene;

        public void StartGame()
        {
            SceneManager.LoadScene(gameStartScene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}