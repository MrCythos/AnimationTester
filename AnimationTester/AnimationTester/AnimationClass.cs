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
        //This will just return a single image. nothing too important
        //remember to set the currentframe.x to zero/0 outside of this method. or else you will encounter the flashing issue.
        public static int AnimationStill(Point currentFrame) //Point currentFrame
        {
            currentFrame.X = 0;
            return currentFrame.X;
        }
        
        //this will loop animations from 1-whatever
        public static int AnimationLoop(Point currentFrame, Point sheetSize)
        {
            ++currentFrame.X;
            if (currentFrame.X == sheetSize.X)
                currentFrame.X = 0;
            return currentFrame.X;
        }
        
        //this will maybe loop backwards? doublecheck later
        public static int AnimationLoopBackwards(Point currentFrame, Point sheetSize)
        {
            --currentFrame.X;
            if (currentFrame.X == 0)
                currentFrame.X = sheetSize.X;
            return currentFrame.X;
        }

        //this should play an animation and hold it on the last frame.
        public static int AnimationPlay(Point currentFrame, int lengthOfAnimation)
        {
            if (currentFrame.X < lengthOfAnimation)
            {
                ++currentFrame.X;
            }
            return currentFrame.X;
        }

        //a method to play an animation and reset it to the first frame. it may be easier just to make a different spritesheet for this kind of animation
        //or do a logic if/loop animationplay else animationstill
        public static int AnimationPlayReset()
        {
            return 0;
        }

    }
}
