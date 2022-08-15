using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RunnerPlayer : MonoBehaviour
{
    [SerializeField][Min(0)] private int _health = 3;
    public int Health => _health;

    public event UnityAction<int> HealthChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Trap trap))
        {
            ReceiveDamage();
        }
    }

    private void ReceiveDamage()
    {
        _health--;
        HealthChanged?.Invoke(_health);

        if(_health == 0 )
        {
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}