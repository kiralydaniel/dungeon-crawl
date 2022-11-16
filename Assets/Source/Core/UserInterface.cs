﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Source.Core
{
    /// <summary>
    ///     Class for handling text on user interface (UI)
    /// </summary>
    public class UserInterface : MonoBehaviour
    {
        public enum TextPosition : byte
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        /// <summary>
        ///     User Interface singleton
        /// </summary>
        public static UserInterface Singleton { get; private set; }

        private TextMeshProUGUI[] _textComponents;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }
            
            Singleton = this;

            _textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        }

        /// <summary>
        ///     Changes text at given screen position
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textPosition"></param>
        public void SetText(string text, TextPosition textPosition)
        {
            _textComponents[(int) textPosition].text = text;
        }
        
        public void PrintInterface(Dictionary<string, int> inventory,int maxHealth, int health, int strength, int armor)
        {
            string inventoryToPrint = string.Empty;
            string items = string.Empty;
            foreach (var item in inventory)
            {
                if (item.Value > 0)
                {
                    items += $"{(char.ToUpper(item.Key[0])) + item.Key.Substring(1)} x{item.Value}\n";
                }
            }
            if (items != string.Empty)
            {
                inventoryToPrint += "Inventory:\n" + items;
            }
            Singleton.SetText(inventoryToPrint, TextPosition.BottomRight);
            Singleton.SetText($"HP: {health}/{maxHealth}\nARMOR: {armor}\nDAMAGE: {strength} " , UserInterface.TextPosition.BottomLeft);
        }
        
    }
}
