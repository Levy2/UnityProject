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

        [SerializeField] private Transform playerCar;
        [SerializeField] private Transform greenCar;
        [SerializeField] private Transform blueCar;

        #endregion

        private void Start()
        {
            playerCar.DOLocalMoveZ(-7.19f, 3).SetEase(Ease.OutQuint);
            greenCar.DOLocalMove(new Vector3 (34.63f, 0.54f, -18.73f), 3).SetEase(Ease.OutQuint);
            blueCar.DOLocalMoveZ(-31.08f, 3).SetEase(Ease.OutQuint); 
        }
    }
}

