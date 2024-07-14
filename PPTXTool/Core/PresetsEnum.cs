using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTXTool.Core
{
    public enum PresetsEnum
    {
        #region Entrance Effects
        EntranceAppear = 0,
        EntranceFade = 1,
        EntranceFlyIn = 2,
        EntranceFloatIn = 3,
        EntranceSplit = 4,
        EntranceWipe = 5,
        EntranceGrowAndTurn = 6,
        EntranceZoom = 7,
        EntranceBounce = 8,
        #endregion

        #region Exit Effects
        ExitDisappear = 9,
        ExitFade = 10,
        ExitFlyOut = 11,
        ExitFloatOut = 12,
        ExitSplit = 13,
        ExitWipe = 14,
        ExitShrinkTurn = 15,
        ExitZoom = 16,
        ExitBounce = 17,
        #endregion


        #region Emphasis
        EmphasisChangeFillColor = 18,
        EmphasisChangeFontColor = 19,
        EmphasisChangeFontSize = 20,
        EmphasisChangeFontStyle = 21,
        EmphasisGrowShrink = 22,
        EmphasisSpin = 23,
        EmphasisTransparency = 24,
        EmphasisFlashBulb = 25,
        #endregion


        #region Motion Path Effects
        MotionLines = 26,
        MotionArcs = 27,
        MotionTurns = 28,
        MotionShapes = 29,
        MotionLoops = 30,
        MotionCustomPath = 31,
        #endregion
    }

}
