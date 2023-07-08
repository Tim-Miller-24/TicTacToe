using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MillerSoft.TicTacToe
{
    public class MapCreator
    {
        public Map Map => _map;

        private Cell _cellPrefab;

        private Map _map;

        private Transform _root;

        private List<Cell> _cells;

        public MapCreator (Cell cellPrefab, Transform root)
        {
            _cellPrefab = cellPrefab;
            _root = root;
        }

        public List<Cell> Create()
        {
            _map = new Map();

            _cells = _map.CreateMap(_cellPrefab, _root);

            var cellsArray = _cells.ToArray();
            
            Array.Reverse(cellsArray);

            cellsArray.Positiate(_cellPrefab.transform);

            return _cells;
        }
    }
}
