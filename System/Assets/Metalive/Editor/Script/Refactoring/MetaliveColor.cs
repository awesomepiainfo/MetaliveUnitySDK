/*
 * brunch : phantom
 * update : 2023-03-10
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metalive
{
    public class MetaliveColor
    {

        #region UnityColor

        /// <summary>
        /// #EEEEEE -> a = 0
        /// RGBA(255, 255, 255, 0)
        /// </summary>
        public static Color zero => new Color(0, 0, 0, 0);

        /// <summary>
        /// #E0E0E0
        /// RGBA(224, 224, 224, 0)
        /// </summary>
        public static Color gainsboro => new Color(0.8789f, 0.8789f, 0.8789f, 1);

        /// <summary>
        /// #505050
        /// RGBA(80, 80, 80, 0)
        /// </summary>
        public static Color matterhorn => new Color(0.3164f, 0.3164f, 0.3164f, 1);

        /// <summary>
        /// #484848
        /// RGBA(72, 72, 72, 0)
        /// </summary>
        public static Color charcoal => new Color(0.2852f, 0.2852f, 0.2852f, 1);


        /// <summary>
        /// #404040
        /// RGBA(64, 64, 64, 0)
        /// </summary>
        public static Color eclipse => new Color(0.2539f, 0.2539f, 0.2539f, 1);

        /// <summary>
        /// #383838
        /// RGBA(56, 56, 56, 0)
        /// </summary>
        public static Color darkEclipse => new Color(0.2227f, 0.2227f, 0.2227f, 1);

        #endregion

    }
}

#endif