//-----------------------------------------------------------------------
// <copyright file="TweenHandler.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DriVR.Scenario
{
    public class TweenHandler : MonoBehaviour
    {
        #region Fields

        Sequence uiQuestionSequence;

        private static TweenHandler instance;

        [SerializeField] private Transform uiQuestion;

        #endregion

        #region Properties and Indexers

        public static TweenHandler Instance { get { return instance; } private set { instance = value; } }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
        }

        private void Start()
        {
            MakeElementsTransparent();
        }

        #endregion

        #region Methods

        private void MakeElementsTransparent()
        {
            uiQuestion.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }

        public void SequenceUiQuestion()
        {
            uiQuestion.GetComponent<CanvasGroup>().DOFade(1, 1).SetDelay(10);
        }

        #endregion
    }
}

