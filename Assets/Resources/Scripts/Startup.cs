using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MillerSoft.TicTacToe
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private Cell _cellPrefab;

        [SerializeField] private EndGamePopUp _endGamePopUp;

        [SerializeField] private PlayAgainButton _playAgainButton;

        private MapCreator _mapCreator;

        private GameCore _gameCore;

        private void Start()
        {
            _mapCreator = new MapCreator(_cellPrefab, transform);

            var cellList = _mapCreator.Create();

            _gameCore = new GameCore(_mapCreator.Map);

            _gameCore.Initialize();
            _gameCore.Subscribe(cellList);

            _endGamePopUp.Subscribe(_gameCore);

            _playAgainButton.GetGameCore(_gameCore, cellList, _mapCreator.Map);
        }
    }
}
