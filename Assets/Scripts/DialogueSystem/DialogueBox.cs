using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Serialization;

namespace CBPXL.DialogueSystem
{
    //TODO: Make this class callable from singleton game manager or singleton this
    public class DialogueBox : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] private TextMeshProUGUI _textBox;
        [SerializeField] private string[] _lines;
        [SerializeField] private float _typeSpeed;
        [SerializeField] private int _maxLines;
        private int _lineIndex;
        private int _boxLineIndex;
        #endregion

        #region DEFAULT METHODS
        private void OnEnable()
        {
            InitializeDialogue();
        }
        #endregion

        #region BEHAVIOR METHODS
        private void InitializeDialogue()
        {
            _textBox.text = string.Empty;
            _lineIndex = 0;
            _boxLineIndex = 0;
            StartCoroutine(TypeLine());
        }

        private IEnumerator TypeLine()
        {
            if (_boxLineIndex > _maxLines - 1)
            {
                _textBox.text = string.Empty;
                yield return new WaitForSeconds(_typeSpeed);
            }
            else if (_boxLineIndex != 0)
            {
                _textBox.text += "\n";
            }
            
            foreach (char c in _lines[_lineIndex].ToCharArray())
            {
                _textBox.text += c;
                yield return new WaitForSeconds(_typeSpeed);
            }
            
            NextLine();
        }

        private void NextLine()
        {
            if (_lineIndex < _lines.Length - 1)
            {
                _lineIndex++;
                _boxLineIndex++;
                StartCoroutine(TypeLine());
            }
            else
            {
                StopAllCoroutines();
                gameObject.SetActive(false);
            }
        }

        public void ChangeText(string[] lines)
        {
            _lines = lines;
        }
        #endregion
    }
}