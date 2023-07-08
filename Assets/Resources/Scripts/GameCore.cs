using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MillerSoft.TicTacToe
{
    public class GameCore 
    {
        public event Action<GameCore> GameEnded = delegate { };

        public char Winner => _winner;

        private int _turn = 0;

        private bool _isvictorious;

        private char _winner;

        private Map _map;

        public GameCore (Map map)
        {
            _map = map;
        }

        public void Initialize()
        {
            _turn = 0;
            _winner = ' ';
            _isvictorious = false;
        }

        public void Subscribe(List<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.CellSpriteClicked += CheckClickedCell;
            }
        }

        private void CheckClickedCell(Cell cell)
        {
            if (_isvictorious)
            {
                return;
            }

            _turn++;

            if (_turn % 2 != 0)
            {
                _map.ChangeCellIndexValue(cell.Index, '1');

                cell.SpriteRenderer.sprite = cell.CrossSprite;
            }
            else if (_turn % 2 == 0)
            {
                _map.ChangeCellIndexValue(cell.Index, '2');

                cell.SpriteRenderer.sprite = cell.ZeroSprite;
            }

            CheckForWin();

            if (_isvictorious)
            {
                GameEnded.Invoke(this);
            }

            if (_turn >= 9)
            {
                EndGame();
            }
        }

        private void CheckForWin()
        {
            #region horizontalWin
            if (_map.MapCells[0] == _map.MapCells[1] && _map.MapCells[1] == _map.MapCells[2] && _map.MapCells[0] != ' ')
            {
                _winner = _map.MapCells[0];
                _isvictorious = true;
            }
            else if (_map.MapCells[3] == _map.MapCells[4] && _map.MapCells[4] == _map.MapCells[5] && _map.MapCells[3] != ' ')
            {
                _winner = _map.MapCells[3];
                _isvictorious = true;
            }
            else if (_map.MapCells[6] == _map.MapCells[7] && _map.MapCells[7] == _map.MapCells[8] && _map.MapCells[6] != ' ')
            {
                _winner = _map.MapCells[6];
                _isvictorious = true;
            }
            #endregion

            #region verticalWin
            else if (_map.MapCells[0] == _map.MapCells[3] && _map.MapCells[3] == _map.MapCells[6] && _map.MapCells[0] != ' ')
            {
                _winner = _map.MapCells[0];
                _isvictorious = true;
            }
            else if (_map.MapCells[1] == _map.MapCells[4] && _map.MapCells[4] == _map.MapCells[7] && _map.MapCells[1] != ' ')
            {
                _winner = _map.MapCells[1];
                _isvictorious = true;
            }
            else if (_map.MapCells[2] == _map.MapCells[5] && _map.MapCells[5] == _map.MapCells[8] && _map.MapCells[2] != ' ')
            {
                _winner = _map.MapCells[2];
                _isvictorious = true;
            }
            #endregion

            #region diagonalWin
            else if (_map.MapCells[0] == _map.MapCells[4] && _map.MapCells[4] == _map.MapCells[8] && _map.MapCells[0] != ' ')
            {
                _winner = _map.MapCells[0];
                _isvictorious = true;
            }
            else if (_map.MapCells[2] == _map.MapCells[4] && _map.MapCells[4] == _map.MapCells[6] && _map.MapCells[2] != ' ')
            {
                _winner = _map.MapCells[2];
                _isvictorious = true;
            }
            #endregion

            else
            {
                _isvictorious = false;
            }
        }

        private void EndGame()
        {
            for (int i = 0; i < _map.MapCells.Length; i++)
            {
                _map.ChangeCellIndexValue(i, ' ');
            }
            
            GameEnded.Invoke(this);
        }
    }
}
