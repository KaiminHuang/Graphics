using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using System.Diagnostics;
    class ColorSetting
    {
        private float baseline;
        private float highest;
        private float lowest;
        private float average;
        private int level;

        public void setRoughness(int level)
        {
            this.level = level;
        }
        public void SetBaseLine(float baseline)
        {
            this.baseline = baseline;
        }
        public void setHighest(float highest)
        {
            this.highest = highest;
        }
        public void setLowest(float lowest)
        {
            this.lowest = lowest;
        }
        public void setAverage(float average)
        {
            this.average = average;
        }
        //Returns a color based on the height of pos
        public Color GetColor(Vector3 pos)
        {
            byte red = 0;
            byte green = 0;
            byte blue = 0;
            float c = pos.Y;
            switch (level)
            {
                // The level of SEA
                case 1:
                    if (c > average)
                    {
                        red = (byte)((c - average) / (highest - average));
                        green = (byte)((c - average) / (highest - average) * 74 + 92);
                        blue = (byte)((c - average) / (highest - average) * 8 + 9);
                        break;
                    }
                    else
                    {
                        red = (byte)((c - lowest) * 102 / (average - lowest) );
                        green = (byte)((c - lowest) * 127 / (average - lowest) + 51);
                        blue = (byte)((c - lowest) * 153 / (average - lowest) + 102);
                        break;
                    }

                //The level of the Desert
                case 2:
                    if (c > average)
                    {
                        red = (byte)(255 -(c - average)   * 51  / (highest - average));
                        green = (byte)(204 - (c - average) * 102 / (highest - average) );
                        blue = (byte)(153 - (c - average)  * 153 / (highest - average) );
                        break;
                    }
                    else
                    {
                        red = (byte)((c - lowest)  * 62 / (average - lowest) +193  );
                        green = (byte)((c - lowest)* 50 / (average - lowest) +154  );
                        blue = (byte)((c - lowest) * 46 / (average - lowest) +107  );
                        break;
                    }
                //The level of the Snow Mountain
                case 3:
                    float high = (highest - average) / 3 + average;
                    float low = average - ((average - lowest) / 3);
                    if (c > high)
                    {
                        red = (byte)((c - high) * 65 / (highest - high) + 160);
                        green = (byte)((c - high) * 65 / (highest - high) + 160);
                        blue = (byte)((c - high) * 65 / (highest - high) + 160);
                        break;
                    }
                    else if (c < high && c > average)
                    {
                        red = (byte)(178 - (c - low) * 102/ (high - low));
                        green = (byte)(225 - (c - low) * 72 / (high - low));
                        blue = (byte)(102 - (c - low) * 102/ (high - low));
                        break;
                    }
                    else if (c < average &&c > low )
                    {
                        red = (byte)((c - low) * 178 / (high - low) );
                        green = (byte)((c - low) * 59 / (high - low) + 166);
                        blue = (byte)((c - low) * 85 / (high - low)+17);
                        break;
                    }
                    else
                    {
                        red = (byte)((c - lowest) / (low - lowest));
                        green = (byte)((c - lowest) / (low - lowest) * 74 + 92);
                        blue = (byte)((c - lowest) / (low - lowest) * 8 + 9);
                        break;
                    }


            }
            return new Color(red, green, blue);


            //switch (level)
            //{
            //    // The level of SEA
            //    case 1:
            //        if (c > average)
            //        {
            //            int greenColor = (int)((c - average) / ((highest - average) / 4));
            //            if (greenColor == 0)
            //            {
            //                red = 0;
            //                green = 92;
            //                blue = 9;
            //                break;
            //            }
            //            else if(greenColor ==1){
            //                red = 0;
            //                green = 104;
            //                blue = 10;
            //                break;
            //            }
            //            else if (greenColor == 2)
            //            {
            //                red = 0;
            //                green = 123;
            //                blue = 12;
            //                break;
            //            }
            //            else if (greenColor == 3)
            //            {
            //                red = 1;
            //                green = 142;
            //                blue = 14;
            //                break;
            //            }
            //            else
            //            {
            //                red = 1;
            //                green = 166;
            //                blue = 17;
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            red = (int)((c - lowest) * 50 / (average - lowest) + 150);
            //            green = (int)((c - lowest) * 70 / (average - lowest) + 100);
            //            blue = (int)((c - lowest) * 75 / (average - lowest) + 25);
            //            break;
            //        }

            //    //The level of the Desert
            //    case 2:
            //        break;
            //    //The level of the Snow Mountain
            //    case 3:
            //        break;
            //}
            //byte r = (byte)red;
            //byte g = (byte)green;
            //byte b = (byte)blue;
            //Debug.WriteLine(r+" "+g+" "+ b);
            //Color color = new Color(r,g,b);
            //Debug.WriteLine(color);
            //return color;


            //{
            //    if (c < baseline - 0.2)
            //    {
            //        return new Color(39, 64, 139); // RoyalBlue4
            //    }
            //    else if (c < baseline - 0.15)
            //    {
            //        return new Color(58, 95, 205); // RoyalBlue3
            //    }
            //    else if (c < baseline - 0.1)
            //    {
            //        return new Color(67, 110, 238); // RoyalBlue2
            //    }
            //    else if (c < baseline - 0.05)
            //    {
            //        return new Color(72, 118, 255); // RoyalBlue1
            //    }
            //    else if (c < baseline)
            //    {
            //        return new Color(69, 139, 0); //Green4
            //    }
            //    else if (c < baseline + 0.05)
            //    {
            //        return new Color(102, 205, 0); //Green3
            //    }
            //    else if (c < baseline + 0.1)
            //    {
            //        return new Color(118, 238, 0); //Green2
            //    }
            //    else if (c < baseline + 0.15)
            //    {
            //        return new Color(118, 238, 0); //Green1
            //    }
            //    else if (c < baseline + 0.2)
            //    {
            //        return new Color(139, 137, 137); //Snow4
            //    }
            //    else if (c < baseline + 0.25)
            //    {
            //        return new Color(205, 201, 201); //Snow3
            //    }
            //    else if (c < baseline + 0.3)
            //    {
            //        return new Color(238, 233, 233); //Snow2
            //    }
            //    else
            //    {
            //        return new Color(255, 250, 250); //Snow1
            //    }
            //}
        }
        //public color peakcolor(float y)
        //{
        //    color color = new color();
        //    float eve = initaly;
        //    if (y >= (groughness * 0.5 + eve)) { color = color.smoothstep(color.white, color.lightskyblue, 0.5f); }
        //    else if (y < (groughness * 0.5 + eve) && y >= (groughness * 0.1 + eve)) { color = color.smoothstep(color.lightskyblue, color.lightgreen, 0.5f); }
        //    else if (y < (groughness * 0.1 + eve) && y >= (groughness * (-0.1) + eve)) { color = color.smoothstep(color.lightgreen, color.green, 0.5f); }
        //    else { color = color.smoothstep(color.green, color.blue, 0.5f); }
        //    return color;
        //}
    }
}
