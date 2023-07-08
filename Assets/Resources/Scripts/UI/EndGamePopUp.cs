using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MillerSoft.TicTacToe
{
    public class EndGamePopUp : MonoBehaviour
    {
        [SerializeField] private PlayAgainButton _playAgainButton;

        [SerializeField] private TextMeshProUGUI _textTitle;

        private void Awake() 
        { 
            gameObject.SetActive(false);
        }

        public void Subscribe(GameCore gameCore)
        {
            gameCore.GameEnded += ShowEndPopUp;

            _playAgainButton.RestartButtonClicked += DisablePopUp;
        }

        private void ShowEndPopUp(GameCore gameCore)
        {
            if (gameCore.Winner == '1')
            {
                _textTitle.text = $"Winner : player {gameCore.Winner} (cross)";
            }
            else if (gameCore.Winner == '2')
            {
                _textTitle.text = $"Winner : player {gameCore.Winner} (zero)";
            }
            else
            {
                _textTitle.text = "Game ended. Draw";
            }

            gameObject.SetActive(true);
        }

        private void DisablePopUp()
        {
            gameObject.SetActive(false);
        }
    }
}
