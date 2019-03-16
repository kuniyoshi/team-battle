using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TeamBattle.Extension;
using UnityEngine;

namespace TeamBattle.GatheringInner.AudioManager
{

    public class VoiceWorker
    {

        const float FadeDuration = 0.1f;

        List<AudioSource> _audioSources;
        
        public void Initialize(IEnumerable<AudioSource> audioSources)
        {
            _audioSources = new List<AudioSource>(audioSources);
        }

        public void Play(AudioClip voice)
        {
            var sameClip = _audioSources.FirstOrDefault(a => a.clip == voice);

            if (sameClip && sameClip.isPlaying)
            {
                return;
            }

            if (sameClip)
            {
                sameClip.Play();
            }

            var usable = _audioSources.FirstOrDefault(a => !a.isPlaying);

            if (usable == null)
            {
                return;
            }

            usable.clip = voice;
            usable.DOFade(1f, FadeDuration);
            usable.Play();
        }

        public void Stop(AudioClip voice)
        {
            var sameClip = _audioSources.FirstOrDefault(a => a.clip == voice);

            if (sameClip == null)
            {
                return;
            }
            
            sameClip.Nullable()?.Stop();
        }

    }

}
