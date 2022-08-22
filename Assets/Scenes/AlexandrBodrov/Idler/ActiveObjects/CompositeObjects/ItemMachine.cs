using Agava.IdleGame;
using Agava.IdleGame.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemMachine : MonoBehaviour
{
    [SerializeField] private List<MachineInputItem> _inputs;
    [SerializeField] private List<MachineOutputItem> _outputs;

    [Space]
    [SerializeField][Min(0)] private float _processingTime = 1f;
    [SerializeField] private TimerView _timerView;

    private Timer _timer = new();

    public bool InProcessing { get; private set; }

    public event UnityAction ProcessingStarted;
    public event UnityAction ProcessingFinished;

    private void OnEnable()
    {
        _inputs.ForEach(x => x.ReadinessChanged += OnReadinessChanged);
        _outputs.ForEach(x => x.ReadinessChanged += OnReadinessChanged);

        _inputs.ForEach(x => x.ItemRemoved += OnItemsChanged);
        _timer.Completed += FinishProcessing;
    }

    private void OnDisable()
    {
        _inputs.ForEach(x => x.ReadinessChanged -= OnReadinessChanged);
        _outputs.ForEach(x => x.ReadinessChanged -= OnReadinessChanged);

        _inputs.ForEach(x => x.ItemRemoved -= OnItemsChanged);
        _timer.Completed -= FinishProcessing;
    }

    private void Start()
    {
        _timerView?.Init(_timer);
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
    }

    private void StartProcessing()
    {
        //Debug.Log($"Trying start rocessing. In progressing: {InProcessing}");

        if (InProcessing == false)
        {
            bool inputIsReady = true;
            foreach (var input in _inputs)
            {
                //Debug.Log($"Input ready: {input.IsReady}");

                if (input.IsReady == false)
                {
                    inputIsReady = false;
                    break;
                }
            }

            bool outputIsReady = true;
            foreach (var input in _outputs)
            {
                if (input.IsReady == false)
                {
                    outputIsReady = false;
                    break;
                }
            }

            //Debug.Log($"Input stack: {inputIsReady}, output stack: {outputIsReady}");

            if (inputIsReady && outputIsReady)
            {
                InProcessing = true;
                _inputs.ForEach(x => x.TakeItems());
            }
        }
    }

    private void FinishProcessing()
    {
        InProcessing = false;

        _outputs.ForEach(x => x.GiveItems());
        _inputs.ForEach(x => x.ResetItems());

        //Debug.Log($"Process finished");
        ProcessingFinished?.Invoke();

        StartProcessing();
    }

    private void OnReadinessChanged(bool value)
    {
        StartProcessing();
    }

    private void OnItemsChanged()
    {
        foreach (var input in _inputs)
        {
            Debug.Log($"Input items is removed: {input.ItemsIsRemoved}");

            if (input.ItemsIsRemoved == false)
            {
                return;
            }
        }

        _timer.Start(_processingTime);
        //Debug.Log($"Process started");
        ProcessingStarted?.Invoke();
    }
}