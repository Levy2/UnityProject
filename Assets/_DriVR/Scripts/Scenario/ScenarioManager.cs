//-----------------------------------------------------------------------
// <copyright file="ScenarioManager.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DriVR.Scenario
{
    public class ScenarioManager : MonoBehaviour
    {
        #region Fields

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

        public void StartRestartScenario()
        {
            StartCoroutine(RestartScenario());
        }

        private IEnumerator RestartScenario()
        {
            yield return new WaitForSeconds(2);

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Resources.UnloadUnusedAssets();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        #endregion
    }
}
