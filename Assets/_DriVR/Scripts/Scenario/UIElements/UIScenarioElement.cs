//-----------------------------------------------------------------------
// <copyright file="UIScenarioElement.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DriVR.Scenario
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIScenarioElement : MonoBehaviour
    {
        #region Constants

        private const float waitBeforeFade = 1.0f;
        private const float fadeSpeed = 2.0f;

        #endregion

        #region Fields

        private CanvasGroup canvasGroup;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start the Fade In Routine of the UI element
        /// </summary>
        public void StartUiScenarioElementFadeIn()
        {
            StartCoroutine(UiScenarioElementFadeIn());
        }

        /// <summary>
        /// Start the Fade Out Routine of the UI element
        /// </summary>
        public void StartUiScenarioElementFadeOut()
        {
            StartCoroutine(UiScenarioElementFadeOut());
        }

        private void StartOutcomeSequence()
        {
            //TODO
        }

        /// <summary>
        /// Fade In Routine of the UI element
        /// </summary>
        private IEnumerator UiScenarioElementFadeIn()
        {
            yield return new WaitForSeconds(waitBeforeFade);
            while (canvasGroup.alpha < 1.00f)
            {
                canvasGroup.alpha += Time.deltaTime * fadeSpeed;
                yield return new WaitForEndOfFrame();
            }
        }

        /// <summary>
        /// Fade Out Routine of the UI element
        /// </summary>
        private IEnumerator UiScenarioElementFadeOut()
        {
            yield return new WaitForSeconds(waitBeforeFade);
            
            while (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime * fadeSpeed;

                yield return new WaitForEndOfFrame();

                if (canvasGroup.alpha <= 0.01f)
                {
                    canvasGroup.gameObject.SetActive(false);
                }
            }
        }

        #endregion
    }
}

