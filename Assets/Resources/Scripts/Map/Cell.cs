using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MillerSoft.TicTacToe
{
    public class Cell : MonoBehaviour
    {
        public int Index { get; private set; }

        public event Action<Cell> CellSpriteClicked = delegate { };

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Sprite CrossSprite => _crossSprite;
        public Sprite ZeroSprite => _zeroSprite;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite _crossSprite;
        [SerializeField] private Sprite _zeroSprite;
        [SerializeField] private Sprite _whiteSprite;

        private bool _isClicked;

        private void Awake()
        {
            _isClicked = false;
        }

        private void OnMouseDown()
        {
            if (_isClicked)
            {
                return;
            }

            CellSpriteClicked.Invoke(this);
            _isClicked = true;
        }

        public void SetCellIndex(int index)
        {
            Index = index;
        }

        public void ResetCellParams()
        {
            _isClicked = false;

            _spriteRenderer.sprite = _whiteSprite;
        }
    }
}
