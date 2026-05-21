using Common;
using UnityEngine;

namespace Offsets
{
    internal class SwitchOffsetButton : AbstractButton
    {
        [SerializeField] private OffsetContainer _offset;
        [SerializeField] private bool _isNext;
    
        protected override void HandleClick()
        {
            if (_isNext)
            {
                _offset.Next();
            }
            else
            {
                _offset.Previous();
            }
        }
    }
}