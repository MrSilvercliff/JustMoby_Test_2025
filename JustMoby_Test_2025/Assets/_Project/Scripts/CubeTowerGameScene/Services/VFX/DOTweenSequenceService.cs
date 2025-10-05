using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceService
    {
        void StartCubeDisappearSequence(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition);
        void StartCubeMoveToHoleSequence();

        void OnSequenceStartPlay(IDOTweenSequenceData sequenceData);
        void OnSequenceFinished(IDOTweenSequenceData sequenceData);
    }

    public class DOTweenSequenceService : IDOTweenSequenceService
    {
        [Inject] private IDOTweenSequenceDataRepository _sequenceDataRepository;
        [Inject] private IDOTweenSequenceDataCreator _sequenceDataCreator;

        public void StartCubeDisappearSequence(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition)
        {
            var data = _sequenceDataCreator.CreateSequenceData(cubeBalanceModel, eventDataPointerPosition);
            _sequenceDataRepository.Add(data);
        }

        public void StartCubeMoveToHoleSequence()
        {
        }

        public void OnSequenceStartPlay(IDOTweenSequenceData sequenceData)
        {
            _sequenceDataRepository.Remove(sequenceData);
            _sequenceDataRepository.AddPlayingSequence(sequenceData);
        }

        public void OnSequenceFinished(IDOTweenSequenceData sequenceData)
        {
            _sequenceDataRepository.RemovePlayingSequence(sequenceData);
        }
    }
}