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
        private static bool _Wireframe = false;
        public static bool Wireframe
        {
            get { return _Wireframe; }
            set 
            { 
                _Wireframe = value;
            }
        }
        #endregion
    }
}
