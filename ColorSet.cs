using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    class ColorSet
    {
       private float baseline;
       public void setBaseline(float baseline)
       {
           this.baseline = baseline;
       }
       public Color GetColor(Vector3 pos)
        {

            float c = pos.Y;
            {
                if (c < baseline - 0.2)
                {
                    return new Color(39, 64, 139); // RoyalBlue4
                }
                else if (c < baseline - 0.15)
                {
                    return new Color(58, 95, 205); // RoyalBlue3
                }
                else if (c < baseline - 0.1)
                {
                    return new Color(67, 110, 238); // RoyalBlue2
                }
                else if (c < baseline - 0.05)
                {
                    return new Color(72, 118, 255); // RoyalBlue1
                }
                else if (c < baseline)
                {
                    return new Color(69, 139, 0); //Green4
                }
                else if (c < baseline + 0.05)
                {
                    return new Color(102, 205, 0); //Green3
                }
                else if (c < baseline + 0.1)
                {
                    return new Color(118, 238, 0); //Green2
                }
                else if (c < baseline + 0.15)
                {
                    return new Color(118, 238, 0); //Green1
                }
                else if (c < baseline + 0.2)
                {
                    return new Color(139, 137, 137); //Snow4
                }
                else if (c < baseline + 0.25)
                {
                    return new Color(205, 201, 201); //Snow3
                }
                else if (c < baseline + 0.3)
                {
                    return new Color(238, 233, 233); //Snow2
                }
                else
                {
                    return new Color(255, 250, 250); //Snow1
                }
            }
        }
    }
}
