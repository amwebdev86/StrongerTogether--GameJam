﻿using System.Collections;
using System.Collections.Generic;

namespace SPACE.Utils
{
    public static class GameUtility 
    {
        public static int RandomNum(int min, int max)
        {
            System.Random _random = new System.Random();
            
            return _random.Next(min, max);
        }
    }

}