using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MillerSoft.TicTacToe
{
    public static class MapPositioner
    {
        public static void Positiate(this Cell[] cells, Transform cellScale)
        {
            var cellSize = cellScale.localScale.x;

            cells[0].transform.localPosition = new Vector3(0 - cellSize, 0 + cellSize);
            cells[1].transform.localPosition = new Vector3(0, 0 + cellSize);
            cells[2].transform.localPosition = new Vector3(0 + cellSize, 0 + cellSize);
            cells[3].transform.localPosition = new Vector3(0 - cellSize, 0);
            cells[4].transform.localPosition = new Vector3(0, 0);
            cells[5].transform.localPosition = new Vector3(0 + cellSize, 0);
            cells[6].transform.localPosition = new Vector3(0 - cellSize, 0 - cellSize);
            cells[7].transform.localPosition = new Vector3(0, 0 - cellSize);
            cells[8].transform.localPosition = new Vector3(0 + cellSize, 0 - cellSize);
        }
    }
}
