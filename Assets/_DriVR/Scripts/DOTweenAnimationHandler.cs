//-----------------------------------------------------------------------
// <copyright file="DOTweenAnimationHandler.cs" company="DriVR Inc.">
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
    public class DOTweenAnimationHandler : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform playerCar;

        #endregion

        private void Start()
        {
            playerCar.DOMoveZ(2.3f, 5).SetEase(Ease.OutQuint);
        }
    }
}

