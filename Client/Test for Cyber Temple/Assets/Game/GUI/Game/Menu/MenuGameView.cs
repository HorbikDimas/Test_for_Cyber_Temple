using System;
using System.Globalization;
using Game.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.GUI.Game.Menu
{
    public class MenuGameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cristalText;
        [SerializeField] private Button startGameButton;
        [SerializeField] private TMP_Dropdown complexityDropdown;
        [SerializeField] private TMP_Dropdown cristalSpawnDropdown;
        [SerializeField] private TMP_InputField speedInputField;
        private GameSettings _settings;
        private SignalBus _signalBus;

        private void OnEnable()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            cristalText.text = PlayerPrefs.GetInt("Cristal").ToString();
            complexityDropdown.onValueChanged.AddListener(OnComplexityChanged);
            cristalSpawnDropdown.onValueChanged.AddListener(OnCristalSpawnChanged);
            speedInputField.text = _settings.GameSpeed.ToString(CultureInfo.InvariantCulture);
            speedInputField.onValueChanged.AddListener(OnSpeedChanged);
        }

        private void OnDisable()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            complexityDropdown.onValueChanged.RemoveListener(OnComplexityChanged);
            cristalSpawnDropdown.onValueChanged.RemoveListener(OnCristalSpawnChanged);
        }

        private void OnSpeedChanged(string speed)
        {
            _settings.GameSpeed = Convert.ToSingle(speed);
        }

        private void OnCristalSpawnChanged(int index)
        {
            _settings.CristalSpawnType = (CristalSpawnType)index;
        }

        private void OnComplexityChanged(int index)
        {
            _settings.ComplexityType = (ComplexityType)index;
        }

        [Inject]
        public void Construct(SignalBus signalBus, GameSettings settings)
        {
            _signalBus = signalBus;
            _settings = settings;
        }

        private void OnStartGameClicked()
        {
            Debug.Log("srdfg");
            _signalBus.Fire(new ButtonClickedSignal(ViewType.Round));
        }
    }
}