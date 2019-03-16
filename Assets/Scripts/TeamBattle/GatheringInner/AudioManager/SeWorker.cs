using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBattle.GatheringInner.AudioManager
{

    public class SeWorker
    {

        List<AudioSource> _audioSources;

        public void Initialize(IEnumerable<AudioSource> audioSources)
        {
            _audioSources = new List<AudioSource>(audioSources);
        }

        public void Play(AudioClip se)
        {
            var usable = _audioSources.FirstOrDefault(a => !a.isPlaying);

            if (usable == null)
            {
                return;
            }

            usable.clip = se;
            usable.Play();
        }


    }

}
