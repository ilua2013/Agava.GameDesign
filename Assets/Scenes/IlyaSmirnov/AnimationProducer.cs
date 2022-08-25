using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.IdleGame;

public class AnimationProducer : MonoBehaviour
{
    [SerializeField] private ObjectProducerZone _producer;
    [SerializeField] private List<ParticleSystem> _particle = new List<ParticleSystem>();
    [SerializeField] private List<Transform> _child = new List<Transform>();
    [SerializeField] private float _delayParticle1;
    [SerializeField] private float _delayParticle2;

    private Animator _animator;

    private const string c_CreateObject = "CreateObject";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _producer.Timer.Started += PlayAnimation;
        _producer.Trigger.Exit += StopAnimation;
    }

    private void OnDisable()
    {
        _producer.Timer.Started -= PlayAnimation;
        _producer.Trigger.Exit -= StopAnimation;
    }

    private void PlayAnimation()
    {
        _animator.enabled = true;
        foreach (var item in _child)
        {
            item.gameObject.SetActive(true);
        }

        _animator.SetTrigger(c_CreateObject);
        StartCoroutine(PlayParticle());
    }

    private void StopAnimation(StackPresenter a)
    {
        _animator.enabled = false;
        foreach (var item in _child)
        {
            item.gameObject.SetActive(false);
        }
    }

    private IEnumerator PlayParticle()
    {
        yield return new WaitForSeconds(_delayParticle1);

        for (int i = 0; i < _particle.Count; i++)
        {
            if (!_particle[i].isPlaying)
            {
                _particle[i].Play();
                i = _particle.Count;
            }
        }

        yield return new WaitForSeconds(_delayParticle2);

        for (int i = 0; i < _particle.Count; i++)
        {
            if (!_particle[i].isPlaying)
            {
                _particle[i].Play();
                i = _particle.Count;
            }
        }
    }
}
