using Lumen.Character.Spawner;
using Lumen.Services;
using TMPro;
using UnityEngine;

namespace Lumen.UI.Spawners
{
    public class SpawnerView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _minDelayInputField;
        [SerializeField]
        private TMP_InputField _maxDelayInputField;
        [SerializeField]
        private SpawnerType _spawnerType;

        private CharacterSpawner _characterSpawner;

        private void Start()
        {
            _characterSpawner = ServiceLocator.Instance.Get<SpawnerService>().GetSpawner(_spawnerType);

            ResetFields();
            _minDelayInputField.onSubmit.AddListener(OnSubmitChangeOnMinDelay);
            _maxDelayInputField.onSubmit.AddListener(OnSubmitChangeOnMaxDelay);
            _minDelayInputField.onDeselect.AddListener(delegate(string text) { ResetFields(); });
        }

        private void ResetFields()
        {
            _minDelayInputField.text = _characterSpawner.CurrentMinSpawnDelay.ToString();
            _maxDelayInputField.text = _characterSpawner.CurrentMaxSpawnDelay.ToString();
        }

        private void OnSubmitChangeOnMinDelay(string submitText)
        {
            if(float.TryParse(submitText, out float result))
            {
                _minDelayInputField.text = submitText;
                _characterSpawner.CurrentMinSpawnDelay = result;
            }
            else
            {
                _minDelayInputField.text = _characterSpawner.CurrentMinSpawnDelay.ToString();
            }
        }

        private void OnSubmitChangeOnMaxDelay(string submitText)
        {
            if (float.TryParse(submitText, out float result))
            {
                _maxDelayInputField.text = submitText;
                _characterSpawner.CurrentMaxSpawnDelay = result;
            }
            else
            {
                _maxDelayInputField.text = _characterSpawner.CurrentMaxSpawnDelay.ToString();
            }
        }
    }


}