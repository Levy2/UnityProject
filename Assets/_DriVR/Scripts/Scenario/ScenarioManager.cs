//-----------------------------------------------------------------------
// <copyright file="ScenarioManager.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DriVR.Scenario
{
    public class ScenarioManager : MonoBehaviour
    {
        #region Fields

        [Header("Elements prefabs")]
        [Tooltip("The prefab for the Question element prefab.")]
        [SerializeField] private UIQuestion uiQuestionGameobject;
        [Tooltip("The prefab for the Answer element prefab.")]
        [SerializeField] private UIAnswer uiAnswerPrefab;

        private static ScenarioManager instance;

        #endregion

        #region Properties and Indexers

        public static ScenarioManager Instance { get { return instance; } private set { instance = value; } }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
        }

        #endregion

        #region Methods

        private void SwitchToNextScenario()
        {

        }

        private void LoadScenarioUiElements()
        {

        }

        private void StartNewGame()
        {

        }

        private void StartAnimation(bool correctAnswer)
        {

        }

        #endregion
    }
}
