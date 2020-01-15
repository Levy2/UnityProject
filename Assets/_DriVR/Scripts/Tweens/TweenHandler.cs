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
using TMPro;

namespace DriVR.Scenario
{
    public class TweenHandler : MonoBehaviour
    {
        #region Fields

        private static TweenHandler instance;

        private Sequence uiQuestionSequence;
        private Sequence sequenceAnswerIncorrect;

        [SerializeField] private Transform uiQuestion;
        [SerializeField] private Transform blackCube;
        [SerializeField] private TextMeshProUGUI frontShieldTextWrong;
        [SerializeField] private TextMeshProUGUI frontShieldTextConsequence;

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
            sequenceAnswerIncorrect = DOTween.Sequence();

            MakeElementsTransparent();
        }

        #endregion

        #region Methods

        private void MakeElementsTransparent()
        {
            uiQuestion.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            blackCube.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(0,0,0,0);
            frontShieldTextWrong.alpha = 0;
            frontShieldTextConsequence.alpha = 0;
        }

        public void SequenceUiQuestion()
        {
            uiQuestion.GetComponent<CanvasGroup>().DOFade(1, 1).SetDelay(10);
        }

        public void SequenceAnswerIncorrect()
        {
            sequenceAnswerIncorrect.Append(frontShieldTextWrong.DOFade(1, 1))
            .AppendInterval(3)
            .Append(frontShieldTextWrong.DOFade(0, 1))
            .Append(blackCube.gameObject.GetComponent<MeshRenderer>().material.DOColor(new Color32(0, 0, 0, 255), 1.5f))
            .Join(frontShieldTextConsequence.DOFade(1, 1))
            .AppendInterval(3)
            .Append(frontShieldTextConsequence.DOFade(0, 1));
            sequenceAnswerIncorrect.Goto(0, true);
            sequenceAnswerIncorrect.AppendCallback(() => TweensQuestion1.Instance.StartSequenceQuestionIncorrect());
        }

        #endregion
    }
}

