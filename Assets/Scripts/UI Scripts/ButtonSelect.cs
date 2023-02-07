using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
    [RequireComponent(typeof(Button))]
    public class ButtonSelect : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.Select();
        }
    }
}
