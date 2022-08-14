using Agava.IdleGame;
using RunnerMovementSystem;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _rewardAmount = 1;
    //[SerializeField] private ParticleSystem _collectParticle;
    [SerializeField] private SoftCurrencyHolder _softCurrencyHolder;

    public int RewardAmount => _rewardAmount;

    public void Collect()
    {
        //_collectParticle.transform.parent = null;
        ////_collectParticle.Play();
        //_softCurrencyHolder.Add(_rewardAmount);

        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out SoftCurrencyHolder softCurrencyHolder))
    //    {
    //        Collect();
    //    }
    //}
}
