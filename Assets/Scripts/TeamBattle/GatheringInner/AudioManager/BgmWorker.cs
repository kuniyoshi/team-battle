using DG.Tweening;
using UnityEngine;

namespace TeamBattle.GatheringInner.AudioManager
{

    public class BgmWorker
    {

        const float CrossFadeDuration = 3f;

        const float QuitDuration = 0.2f;
        
        #region SourceField

        AudioSource _mainSource;
        
        AudioSource _standbySource;
        
        AudioSource _stoppingSource;
        
        #endregion
        
        #region SequenceField

        Sequence _crossFadeSequence;

        Sequence _stoppingSequence;
        
        #endregion

        public void Initialize(AudioSource mainSource,
                               AudioSource standbySource,
                               AudioSource stoppingSource)
        {
            _mainSource = mainSource;
            _standbySource = standbySource;
            _stoppingSource = stoppingSource;
        }

        public void CrossFade(AudioClip audioClip)
        {
            var isFading = _crossFadeSequence?.IsPlaying() ?? false;

            var isAlreadyPlayingThis = (!isFading && audioClip == _mainSource.clip)
                                       || (isFading && audioClip == _standbySource.clip);

            if (isAlreadyPlayingThis)
            {
                return;
            }

            if (isFading)
            {
                _crossFadeSequence.Kill(complete: false);
                _stoppingSequence?.Kill(complete: true);

                var newStandbySource = _stoppingSource;
                _stoppingSource = _mainSource;
                _mainSource = _standbySource;
                _standbySource = newStandbySource;

                _stoppingSequence = DOTween.Sequence()
                    .Append(
                        _stoppingSource.DOFade(0f, QuitDuration)
                    );

                _stoppingSequence.onComplete += () =>
                {
                    _stoppingSource.Stop();
                    _stoppingSource.clip = null;
                };
            }

            _standbySource.clip = audioClip;
            _standbySource.volume = 0f;

            _crossFadeSequence = DOTween.Sequence();
            _crossFadeSequence.Append(
                _mainSource.DOFade(0f, CrossFadeDuration)
            );

            _crossFadeSequence.Join(
                _standbySource.DOFade(1f, CrossFadeDuration)
            );

            _crossFadeSequence.onComplete += () =>
            {
                var newStandby = _mainSource;
                _mainSource = _standbySource;
                _standbySource = newStandby;

                _standbySource.Stop();
                _standbySource.clip = null;
            };

            _crossFadeSequence.Play();

            if (_mainSource.clip != null && !_mainSource.isPlaying)
            {
                _mainSource.Play();
            }

            if (_standbySource.clip != null && !_standbySource.isPlaying)
            {
                _standbySource.Play();
            }
        }

    }

}
