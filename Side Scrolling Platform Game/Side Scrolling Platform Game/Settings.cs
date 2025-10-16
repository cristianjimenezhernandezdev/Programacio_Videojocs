using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Side_Scrolling_Platform_Game
{
    public static class Settings
    {
      
        
            public static bool goleft = false;// boolean which will control players going left 
            public static bool goright = false; // boolean which will control players going right 
            public static bool jumping = false; // boolean to check if player is jumping or not 
            public static bool hasKey = false; // default value of whether the player has the key 
            public static int jumpSpeed = 10; // integer to set jump speed 
            public static int force = 8; // force of the jump in an integer 
            public static int score = 0; // default score integer set to 0 
            public static int playSpeed = 18; //this integer will set players speed to 18 
            public static int backLeft = 8; // this integer will set the background moving speed to 8
            public static int skyLeft = 4; // this integer will set the background moving speed to 8
        
    }
}

