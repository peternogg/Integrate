using System;

namespace Integrate
{
    /// <summary>
    /// A singular regulatory system to store and retrieve user-editable options
    /// Accessable from (nearly) everywhere. 
    /// </summary>
    public static class OptionBank
    {
        #region Cylinder Options
        // Backing variables
        private static bool _Wireframe = false, _DrawTrunkLines = true, _DrawCapLines = true;
        public static bool Wireframe
        {
            get { return _Wireframe; }
            set 
            { 
                _Wireframe = value;
                // If wireframe is enabled but the two lines are both set to be off
                if (!_DrawCapLines && !_DrawTrunkLines)
                {
                    // Activate both for wireframe mode
                    _DrawTrunkLines = true; _DrawCapLines = true;

                }
            }
        }

        public static bool DrawTrunkLines
        {
            get { return _DrawTrunkLines; }
            set { _DrawTrunkLines = value; }
        }

        public static bool DrawCapLines
        {
            get { return _DrawCapLines; }
            set { _DrawCapLines = value; }
        }
        #endregion
    }
}
