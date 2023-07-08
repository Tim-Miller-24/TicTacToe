using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MillerSoft.TicTacToe
{
    public class PlayAgainButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action RestartButtonClicked = delegate { };

        private Button _restartButton;

        private GameCore _gameCore;

        private List<Cell> _cells;

        private Map _map;

        private void Awake()
        {
            _restartButton = GetComponent<Button>();
        }

        public void GetGameCore(GameCore gameCore, List<Cell> cells, Map map)
        {
            _gameCore = gameCore;
            _cells = cells;
            _map = map;
        }

        private void RestartGame(GameCore gameCore)
        {
            gameCore.Initialize();

            for (int i = 0; i < _cells.Count; i++)
            {
                _cells[i].ResetCellParams();
                _map.ChangeCellIndexValue(i, ' ');

            }

            RestartButtonClicked.Invoke();
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            RestartGame(_gameCore);
        }
    }
}
