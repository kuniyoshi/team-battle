using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TeamBattle.GatheringInner.AudioManager;
using UnityEngine;
using UnityEngine.Assertions;

namespace TeamBattle
{

    public class AudioManager : MonoBehaviour
    {

        #region Serialize Field

        public List<AudioSource> BgmAudioSources;

        public List<AudioSource> VoiceAudioSources;

        public List<AudioSource> SeAudioSources;

        #endregion

        BgmWorker BgmWorker { get; } = new BgmWorker();
        
        VoiceWorker VoiceWorker { get; } = new VoiceWorker();
        
        SeWorker SeWorker { get; } = new SeWorker();

        void Awake()
        {
            AssertSerializeFieldValid();
            BgmWorker.Initialize(
                BgmAudioSources[0],
                BgmAudioSources[1],
                BgmAudioSources[2]
            );
            VoiceWorker.Initialize(VoiceAudioSources);
            SeWorker.Initialize(SeAudioSources);
        }

        public void PlayBgm(AudioClip bgm)
        {
            BgmWorker.CrossFade(bgm);
        }

        public void PlaySe(AudioClip se)
        {
            SeWorker.Play(se);
        }

        public void PlayVoice(AudioClip voice)
        {
            VoiceWorker.Play(voice);
        }

        [Conditional("DEBUG")]
        private void AssertSerializeFieldValid()
        {
            Assert.IsTrue(BgmAudioSources.Any(), "BgmAudioSources.Any()");
            Assert.IsTrue(VoiceAudioSources.Any(), "VoiceAudioSources.Any()");
            Assert.IsTrue(SeAudioSources.Any(), "SeAudioSources.Any()");
            Assert.AreEqual(
                BgmAudioSources.Count,
                new HashSet<AudioSource>(BgmAudioSources).Count
            );

            Assert.AreEqual(
                VoiceAudioSources.Count,
                new HashSet<AudioSource>(VoiceAudioSources).Count
            );

            Assert.AreEqual(
                SeAudioSources.Count,
                new HashSet<AudioSource>(SeAudioSources).Count
            );

            Assert.AreEqual(3, BgmAudioSources.Count);
        }

    }

}
