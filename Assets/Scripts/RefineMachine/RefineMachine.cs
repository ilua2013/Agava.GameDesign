using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class RefineMachine : MonoBehaviour
    {
        private const int PresenterIndex = 0;

        [SerializeField] private List<Transform> _path;
        [SerializeField] private List<StackableObjectPresenter> _cubeVariants;
        [SerializeField] private StackPresenter _stackPresenter;
        [SerializeField] private float _conveyorSpeed;
        [SerializeField] private Sender _sender;

        private bool _isBusy;
        private Coroutine _coroutine;

        public bool IsBusy => _isBusy;

        private void OnEnable()
        {
            _isBusy = false;
            _stackPresenter.Added += PreparRefine;
            _sender.Released += ChangeBusyStatus;
        }

        private void OnDisable()
        {
            _stackPresenter.Added -= PreparRefine;
            _sender.Released -= ChangeBusyStatus;
        }

        private void PreparRefine(StackableObject stackableObject)
        {
            if (_isBusy == true)
                return;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _isBusy = true;
            _coroutine = StartCoroutine(Refine(_stackPresenter.RemoveAt(PresenterIndex)));
        }

        private StackableObjectPresenter CreateNewCube(StackableObjectPresenter currentCube)
        {
            StackableObjectPresenter tempCube = Instantiate(_cubeVariants[Random.Range(0, _cubeVariants.Count)]);
            tempCube.transform.position = currentCube.transform.position;
            Destroy(currentCube.gameObject);
            return tempCube;
        }

        private void ChangeBusyStatus()
        {
            _isBusy = false;
        }

        private IEnumerator Refine(StackableObject stackableObject)
        {
            int pointIndex = 1;
            StackableObjectPresenter tempCube = stackableObject.View.GetComponent<StackableObjectPresenter>();

            while (tempCube.transform.position != _path[pointIndex].position)
            {
                tempCube.transform.position = Vector3.MoveTowards(tempCube.transform.position, _path[pointIndex].position, _conveyorSpeed * Time.deltaTime);

                if (tempCube.transform.position == _path[pointIndex].position)
                {
                    if (++pointIndex >= _path.Count)
                        break;

                    tempCube = CreateNewCube(tempCube);
                }

                yield return null;
            }

            _sender.SetStackableObject(tempCube);
        }
    }
}
