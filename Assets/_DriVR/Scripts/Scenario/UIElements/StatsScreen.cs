//-----------------------------------------------------------------------
// <copyright file="StatsScreen.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace DriVR.Scenario {
    public class StatsScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI statsScreenText;

        private static StatsScreen instance;

        public static StatsScreen Instance { get { return instance; } private set { instance = value; } }

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
        }

        private void Start()
        {
            UpdateStatsText();
        }

        public void UpdateStatsText()
        {
            statsScreenText.text = string.Format("<u>Vraag {0} van {1}</u>\nAantal goed: {2}\nAantal fout: {3}", SceneManager.GetActiveScene().buildIndex + 1, SceneManager.sceneCountInBuildSettings, PointsHandler.Instance.answersCorrect, PointsHandler.Instance.answersWrong);
        }
    }
}