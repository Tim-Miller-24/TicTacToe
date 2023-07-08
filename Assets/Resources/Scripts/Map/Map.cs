using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MillerSoft.TicTacToe
{
    public class Map
    {
        public char[] MapCells => _mapCells;

        private char[] _mapCells = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        public List<Cell> CreateMap(Cell cell, Transform parent)
        {
            var cells = new List<Cell>();

            for (int i = 0; i < MapCells.Length; i++)
            {
                var cellPrefab = Object.Instantiate(cell, parent);

                cells.Add(cellPrefab);

                cellPrefab.SetCellIndex(i);
            }

            return cells;
        }

        public void ChangeCellIndexValue(int index, char value)
        {
            _mapCells[index] = value;
        }
    }
}
