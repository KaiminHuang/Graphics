using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using SharpDX.Toolkit.Input;
using System.Diagnostics;


namespace Project1
{
    class BufferGenerator
    {
        private float pix;
        private float baseline;
        private float landscapeWidth;
        private float landscapeHeight;
        private float lowest = 100;
        private float highest = -100;
        private float average;
        private int iteration;
        private VertexPositionColor[] colorBuffer;
        private Vector3[] buffer;
        private ColorSetting colorSetting;
        private int level;
        private double distance;
        private Vector3 dpos1;
       


        public void setLevel(int level, float landscapeWidth, float landscapeHeight, Vector3 dpos1)
        {
            this.level = level;
            this.landscapeHeight = landscapeHeight;
            this.landscapeWidth = landscapeWidth;
            this.distance = this.landscapeHeight /pix * 0.9;
            this.dpos1 = dpos1;
        }
       
        public BufferGenerator()
        {
            this.colorBuffer = new VertexPositionColor[] { };
            this.buffer = new Vector3[]{};
            this.colorSetting = new ColorSetting();
            
        }
        public VertexPositionColor[] setCannonPos()
        {
            VertexPositionColor cannonPosColor_5 = colorBuffer[0];
            VertexPositionColor cannonPosColor_4 = colorBuffer[0];
            VertexPositionColor cannonPosColor_3 = colorBuffer[0];
            VertexPositionColor cannonPosColor_2 = colorBuffer[0];
            VertexPositionColor cannonPosColor_1 = colorBuffer[0];
            VertexPositionColor targetPosColor_5 = colorBuffer[0];
            VertexPositionColor targetPosColor_4 = colorBuffer[0];
            VertexPositionColor targetPosColor_3 = colorBuffer[0];
            VertexPositionColor targetPosColor_2 = colorBuffer[0];
            VertexPositionColor targetPosColor_1 = colorBuffer[0];
            Random rnd = new Random();

            //TODO change 2 and 12 according to the landwidth later
            int opt = rnd.Next(2, 30);
            double targetX = dpos1.X + opt * pix;
            double targetZ = Math.Sqrt((distance * distance - opt * opt));
            targetZ = Math.Round(targetZ);
            targetZ = dpos1.Z - targetZ * pix;
      
            for (int i = 3; i <= colorBuffer.Length - 1 -3 ; i++)
            {
                VertexPositionColor posColor5 = colorBuffer[i-1];
                VertexPositionColor posColor4 = colorBuffer[i+3];
                VertexPositionColor posColor3 = colorBuffer[i-3];
                VertexPositionColor posColor2 = colorBuffer[i-2];
                VertexPositionColor posColor1 = colorBuffer[i];
                // for target position
                if (posColor1.Position.X == targetX && posColor1.Position.Z == targetZ
                    && posColor2.Position.X == targetX + pix && posColor2.Position.Z == targetZ
                    && posColor3.Position.X == targetX + pix && posColor3.Position.Z == targetZ - pix 
                    && posColor4.Position.X == targetX && posColor4.Position.Z == targetZ - pix)
                {
                    float averageHight = (posColor1.Position.Y + posColor2.Position.Y + posColor3.Position.Y + posColor4.Position.Y + posColor5.Position.Y) / 5;
                    posColor1.Position.Y = averageHight;
                    posColor2.Position.Y = averageHight;
                    posColor3.Position.Y = averageHight;
                    posColor4.Position.Y = averageHight;
                    posColor5.Position.Y = averageHight;

                    posColor1.Color = new Color(1, 0, 0);
                    posColor2.Color = new Color(1, 0, 0);
                    posColor3.Color = new Color(1, 0, 0);
                    posColor4.Color = new Color(1, 0, 0);
                    posColor5.Color = new Color(1, 0, 0);

                    targetPosColor_5 = posColor5;
                    targetPosColor_4 = posColor4;
                    targetPosColor_3 = posColor3;
                    targetPosColor_2 = posColor2;
                    targetPosColor_1 = posColor1;

                    //Debug.WriteLine("VertexPositionColor  1:    " + posColor1);
                    //Debug.WriteLine("VertexPositionColor  2:    " + posColor2);
                    //Debug.WriteLine("VertexPositionColor  3:    " + posColor3);
                    //Debug.WriteLine("VertexPositionColor  4:    " + posColor4);
                    //Debug.WriteLine("VertexPositionColor  5:    " + posColor5);
                }
                // for cannon position
                if (posColor1.Position.X == dpos1.X + pix * 2f && posColor1.Position.Z == dpos1.Z - pix * 2f 
                    && posColor2.Position.X == dpos1.X + pix * 3f && posColor2.Position.Z == dpos1.Z - pix * 2f
                    && posColor3.Position.X == dpos1.X + pix * 3f && posColor3.Position.Z == dpos1.Z - pix * 3f
                    && posColor4.Position.X == dpos1.X + pix * 2f && posColor4.Position.Z == dpos1.Z - pix * 3f)
                {
                    float averageHight = (posColor1.Position.Y + posColor2.Position.Y + posColor3.Position.Y + posColor4.Position.Y + posColor5.Position.Y)/5;
                    posColor1.Position.Y = averageHight;
                    posColor2.Position.Y = averageHight;
                    posColor3.Position.Y = averageHight;
                    posColor4.Position.Y = averageHight;
                    posColor5.Position.Y = averageHight;

                    posColor1.Color = new Color(1, 0, 0);
                    posColor2.Color = new Color(1, 0, 0);
                    posColor3.Color = new Color(1, 0, 0);
                    posColor4.Color = new Color(1, 0, 0);
                    posColor5.Color = new Color(1, 0, 0);

                    cannonPosColor_5 = posColor5;
                    cannonPosColor_4 = posColor4;
                    cannonPosColor_3 = posColor3;
                    cannonPosColor_2 = posColor2;
                    cannonPosColor_1 = posColor1;

                    //Debug.WriteLine("VertexPositionColor  1:    " + posColor1);
                    //Debug.WriteLine("VertexPositionColor  2:    " + posColor2);
                    //Debug.WriteLine("VertexPositionColor  3:    " + posColor3);
                    //Debug.WriteLine("VertexPositionColor  4:    " + posColor4);
                    //Debug.WriteLine("VertexPositionColor  5:    " + posColor5);

                }
            }
            for (int i = 3; i <= colorBuffer.Length - 1; i++)
            {
                VertexPositionColor posColor = colorBuffer[i];
                if (posColor.Position.X == cannonPosColor_1.Position.X &&
                    posColor.Position.Z == cannonPosColor_1.Position.Z)
                {
                    posColor = cannonPosColor_1;
                }
                if (posColor.Position.X == cannonPosColor_2.Position.X &&
                    posColor.Position.Z == cannonPosColor_2.Position.Z)
                {
                    posColor = cannonPosColor_2;
                }
                if (posColor.Position.X == cannonPosColor_3.Position.X &&
                    posColor.Position.Z == cannonPosColor_3.Position.Z)
                {
                    posColor = cannonPosColor_3;
                }
                if (posColor.Position.X == cannonPosColor_4.Position.X &&
                    posColor.Position.Z == cannonPosColor_4.Position.Z)
                {
                    posColor = cannonPosColor_4;
                }
                if (posColor.Position.X == cannonPosColor_5.Position.X &&
                    posColor.Position.Z == cannonPosColor_5.Position.Z)
                {
                    posColor = cannonPosColor_5;
                }


                if (posColor.Position.X == targetPosColor_1.Position.X &&
                    posColor.Position.Z == targetPosColor_1.Position.Z)
                {
                    posColor = targetPosColor_1;
                }
                if (posColor.Position.X == targetPosColor_2.Position.X &&
                    posColor.Position.Z == targetPosColor_2.Position.Z)
                {
                    posColor = targetPosColor_2;
                }
                if (posColor.Position.X == targetPosColor_3.Position.X &&
                    posColor.Position.Z == targetPosColor_3.Position.Z)
                {
                    posColor = targetPosColor_3;
                }
                if (posColor.Position.X == targetPosColor_4.Position.X &&
                    posColor.Position.Z == targetPosColor_4.Position.Z)
                {
                    posColor = targetPosColor_4;
                }
                if (posColor.Position.X == targetPosColor_5.Position.X &&
                    posColor.Position.Z == targetPosColor_5.Position.Z)
                {
                    posColor = targetPosColor_5;
                }
                colorBuffer[i] = posColor;
            }
            return colorBuffer;
        }

        public void setColorRanges()
        {
            this.colorSetting.setAverage(this.average/iteration);
            this.colorSetting.setHighest(this.highest);
            this.colorSetting.setLowest(this.lowest);
            this.colorSetting.setRoughness(this.level);
        }

        public void SetLandscapeWidth(float landscapeWidth)
        {
            this.landscapeWidth = landscapeWidth;
        }
        public void SetLandscapeHeight(float landscapeHeight)
        {
            this.landscapeHeight = landscapeHeight;
        }
        public void SetBaseLine(float baseline)
        {
            this.baseline = baseline;
            colorSetting.SetBaseLine(baseline);
        }
        public void SetPix(float pix)
        {
            this.pix = pix;
        }

        //This is the recursive function that implements the random midpoint
        //displacement algorithm.  It will call itself until the grid pieces
        //become smaller than one pixel.
        public Vector3[] DivideGrid(float x, float z, float width, float height, float c1, float c2, float c3, float c4)
        {
            Random rd = new Random();
            float wr = (float)rd.NextDouble(0, 1.0);
            float hr = (float)rd.NextDouble(0, 1.0);
            float Edge1, Edge2, Edge3, Edge4, Middle;
            float newWidth = width / 2;
            float newHeight = height / 2;
            if (width > pix)
            {
                Middle = (c1 + c2 + c3 + c4) / 4 + Displace(newWidth + newHeight);	//Randomly displace the midpoint   
                Edge1 = (c1 + c2) / 2;	//Calculate the edges by averaging the two corners of each edge.
                Edge2 = (c2 + c3) / 2;
                Edge3 = (c3 + c4) / 2;
                Edge4 = (c4 + c1) / 2;

                //Make sure that the midpoint doesn't accidentally "randomly displaced" past the boundaries!
                if (Middle < 0)
                {
                    Middle = 0;
                }
                else if (Middle > 1.0f)
                {
                    Middle = 1.0f;
                }

                DivideGrid(x, z, newWidth, newHeight, c1, Edge1, Middle, Edge4);
                DivideGrid(x + newWidth, z, newWidth, newHeight, Edge1, c2, Edge2, Middle);
                DivideGrid(x + newWidth, z - newHeight, newWidth, newHeight, Middle, Edge2, c3, Edge3);
                DivideGrid(x, z - newHeight, newWidth, newHeight, Edge4, Middle, Edge3, c4);
            }
            else
            {
                float c = (c1 + c2 + c3 + c4) / 4;
                Vector3 pos1 = new Vector3(x, c1, z);//look from the front, front left up conor
                Vector3 pos2 = new Vector3(x + width, c2, z);//look from the front, front right up conor
                Vector3 pos3 = new Vector3(x + width, c3, z - height);//look from the front, front right down conor
                Vector3 pos4 = new Vector3(x, c4, z - height);//look from the front, front left down conor
                Vector3 posMid = new Vector3(x + width / 2, c, z - height / 2);//look from the front, front left down conor

                //below is for the vextors without color settings
                List<Vector3> bufferList = this.buffer.ToList();
                bufferList.Add(pos4);
                bufferList.Add(posMid);
                bufferList.Add(pos3);
                bufferList.Add(pos2);
                bufferList.Add(posMid);
                bufferList.Add(pos1);
                bufferList.Add(pos1);
                bufferList.Add(posMid);
                bufferList.Add(pos4);
                bufferList.Add(pos3);
                bufferList.Add(posMid);
                bufferList.Add(pos2);
                this.buffer = bufferList.ToArray();
                //to records the tallest height, the lowest height and average height
                check(pos1, pos2, pos3, pos4, posMid);
            };

            return this.buffer;
        }
        public VertexPositionColor[] setColor()
        {
            List<VertexPositionColor> colorBufferList = this.colorBuffer.ToList();
            for (int i = 0; i <= buffer.Length - 1; i++)
            {
                Vector3 pos = buffer[i];
                colorBufferList.Add(new VertexPositionColor(pos, colorSetting.GetColor(pos)));
            }
            this.colorBuffer = colorBufferList.ToArray();
            return colorBuffer;
        }
        //add the base of lanscape
        public VertexPositionColor[] AddBase(Vector3 dpos1, Vector3 dpos2, Vector3 dpos3, Vector3 dpos4)
        {
            List<VertexPositionColor> colorBufferList = this.colorBuffer.ToList();
            Vector3 top1 = dpos1;
            Vector3 top2 = dpos2;
            Vector3 top3 = dpos3;
            Vector3 top4 = dpos4;
            top1.Y = top2.Y = top3.Y = top4.Y = 1.5f;

            Vector3 down1 = dpos1;
            Vector3 down2 = dpos2;
            Vector3 down3 = dpos3;
            Vector3 down4 = dpos4;
            down1.Y = down2.Y = down3.Y = down4.Y = 0f;
            // for the front side
            colorBufferList.Add(new VertexPositionColor(dpos4, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down3, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down4, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos4, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos3, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down3, new Color(100, 2, 3)));

            // for the back side
            colorBufferList.Add(new VertexPositionColor(dpos2, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down2, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos2, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down1, new Color(100, 2, 3)));

            // for the left side
            colorBufferList.Add(new VertexPositionColor(dpos1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down4, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos4, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down4, new Color(100, 2, 3)));

            // for the right side
            colorBufferList.Add(new VertexPositionColor(dpos3, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down2, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down3, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos3, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(dpos2, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down2, new Color(100, 2, 3)));

            // for the down side
            colorBufferList.Add(new VertexPositionColor(down1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down3, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down2, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down1, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down4, new Color(100, 2, 3)));
            colorBufferList.Add(new VertexPositionColor(down3, new Color(100, 2, 3)));

            this.colorBuffer = colorBufferList.ToArray();
            return colorBuffer;
        }
        //add the box which contain the lanscape
        public VertexPositionColor[] AddBox(Vector3 dpos1, Vector3 dpos2, Vector3 dpos3, Vector3 dpos4)
        {



            List<VertexPositionColor> colorBufferList = this.colorBuffer.ToList();
            Vector3 top1 = dpos1;
            Vector3 top2 = dpos2;
            Vector3 top3 = dpos3;
            Vector3 top4 = dpos4;
            top1.Y = top2.Y = top3.Y = top4.Y = 1.5f;

            Vector3 down1 = dpos1;
            Vector3 down2 = dpos2;
            Vector3 down3 = dpos3;
            Vector3 down4 = dpos4;
            down1.Y = down2.Y = down3.Y = down4.Y = 0f;
            //top side
        //    VertexPositionTexture(top1, new Vector2(1.0f, 1.0f))
            //// for the top side
            //colorBufferList.Add(new VertexPositionColor(top1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top4, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top3, new Color(1, 2, 3)));

            //// for the down side
            //colorBufferList.Add(new VertexPositionColor(down1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down4, new Color(1, 2, 3)));

            //// for the front side
            //colorBufferList.Add(new VertexPositionColor(top4, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top4, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down4, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down3, new Color(1, 2, 3)));

            //// for the front side
            //colorBufferList.Add(new VertexPositionColor(top1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down1, new Color(1, 2, 3)));

            //// for the left side
            //colorBufferList.Add(new VertexPositionColor(top4, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top4, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down1, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down4, new Color(1, 2, 3)));

            //// for the front side
            //colorBufferList.Add(new VertexPositionColor(top3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top2, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(top3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down3, new Color(1, 2, 3)));
            //colorBufferList.Add(new VertexPositionColor(down2, new Color(1, 2, 3)));
            //this.colorBuffer = colorBufferList.ToArray();
            return colorBuffer;
        }

        //Randomly displaces color value for midpoint depending on size
        //of grid piece.
        private float Displace(float num)
        {

            Random rd = new Random();
            float max = num / (float)(landscapeWidth + landscapeHeight) * 2.0f *level;
            float h = ((float)rd.NextDouble(0, 1) - 0.5f) * max;
            if (num == landscapeWidth)
            {
                baseline += h;
                colorSetting.SetBaseLine(baseline);
            }
            return h;//
        }

        private void check(Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4, Vector3 posMid)
        {
            //for heighest
            if (pos1.Y > highest)
            {
                highest = pos1.Y;
            }
            if (pos2.Y > highest)
            {
                highest = pos2.Y;
            }
            if (pos3.Y > highest)
            {
                highest = pos3.Y;
            }
            if (pos4.Y > highest)
            {
                highest = pos4.Y;
            }
            if (posMid.Y > highest)
            {
                highest = posMid.Y;
            }
            //for lowest
            if (pos1.Y < lowest)
            {
                lowest = pos1.Y;
            }
            if (pos2.Y < lowest)
            {
                lowest = pos2.Y;
            }
            if (pos3.Y < lowest)
            {
                lowest = pos3.Y;
            }
            if (pos4.Y < lowest)
            {
                lowest = pos4.Y;
            }
            if (posMid.Y < lowest)
            {
                lowest = posMid.Y;
            }
            iteration++;
            average += (pos1.Y + pos2.Y + pos3.Y + pos4.Y + posMid.Y) /5;
        }
    }
}
