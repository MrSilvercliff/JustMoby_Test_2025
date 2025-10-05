using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceService
    {
        IReadOnlyCollection<IDOTweenSequenceData> GetSequenceDatas();
        void Clear();

        void StartCubeDisappearSequence(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition);
        void StartCubeMoveToHoleSequence(ICubeDeleteHoleWidget cubeDeleteHoleWidget, ICubeBalanceModel cubeBalanceModel, Vector3 startWorldPosition);
        void StartShowTextSequence(string textLocaleKey);
    }

    public class DOTweenSequenceService : IDOTweenSequenceService
    {
        [Inject] private IDOTweenSequenceDataRepository _sequenceDataRepository;
        [Inject] private IDOTweenSequenceDataCreator _sequenceDataCreator;

        public IReadOnlyCollection<IDOTweenSequenceData> GetSequenceDatas()
        {
            var result = _sequenceDataRepository.GetAll();
            return result;
        }

        public void Clear()
        {
            _sequenceDataRepository.Clear();
        }

        public void StartCubeDisappearSequence(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition)
        {
            var data = _sequenceDataCreator.CreateSequenceData(cubeBalanceModel, eventDataPointerPosition);
            _sequenceDataRepository.Add(data);
        }

        public void StartCubeMoveToHoleSequence(ICubeDeleteHoleWidget cubeDeleteHoleWidget, ICubeBalanceModel cubeBalanceModel, Vector3 startWorldPosition)
        {
            var data = _sequenceDataCreator.CreateSequenceData(cubeDeleteHoleWidget, cubeBalanceModel, startWorldPosition);
            _sequenceDataRepository.Add(data);
        }

        public void StartShowTextSequence(string textLocaleKey)
        {
            var data = _sequenceDataCreator.CreateSequenceData(textLocaleKey);
            _sequenceDataRepository.Add(data);
        }
    }
}