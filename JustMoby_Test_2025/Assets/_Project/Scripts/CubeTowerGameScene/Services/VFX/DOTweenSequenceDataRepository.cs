using Plugins.ZerglingUnityPlugins.Tools.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceDataRepository : IRepositoryList<IDOTweenSequenceData>
    { 
        void AddPlayingSequence(IDOTweenSequenceData sequenceData);
        void RemovePlayingSequence(IDOTweenSequenceData sequenceData);
    }

    public class DOTweenSequenceDataRepository : RepositoryList<IDOTweenSequenceData>, IDOTweenSequenceDataRepository
    {
        private List<IDOTweenSequenceData> _playingSequences;

        public DOTweenSequenceDataRepository() : base() 
        {
            _playingSequences = new();
        }

        public void AddPlayingSequence(IDOTweenSequenceData sequenceData)
        {
            if (_playingSequences.Contains(sequenceData))
                return;

            _playingSequences.Add(sequenceData);
        }

        public void RemovePlayingSequence(IDOTweenSequenceData sequenceData)
        {
            if (!_playingSequences.Contains(sequenceData))
                return;

            _playingSequences.Remove(sequenceData);
        }
    }
}