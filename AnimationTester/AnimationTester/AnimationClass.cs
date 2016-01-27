using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AnimationTester
{
    class AnimationClass
    {
        public static int AnimationLoop(Point currentFrame, Point sheetSize)
        {
            ++currentFrame.X;
            if (currentFrame.X == sheetSize.X)
                currentFrame.X = 0;
            return currentFrame.X;
        }
        public static int AnimationStill(Point currentFrame) //Point currentFrame
        {
            currentFrame.X = 0;
            return currentFrame.X;
        }
        public static int AnimationPlay(Point currentFrame, int lengthOfAnimation)
        {
            if (currentFrame.X <= lengthOfAnimation)
            {
                ++currentFrame.X;
            }
            return currentFrame.X;
        }
    }
}
