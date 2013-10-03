using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;

    public class Normal
    {
        private float pix;
        private VertexPositionColor[] buffer;
        private float landscapeWidth;
        private float landscapeHeight;
        private float baseline = 0;
        ColorSet colorSet = new ColorSet();
        
        public void setLandscapeWidth(float landscapeWidth)
        {
            this.landscapeWidth = landscapeWidth;
        }

        public void setLandscapeHeight(float landscapeHeight)
        {
            this.landscapeHeight = landscapeHeight;
        }

        public void setPix(float pix)
        {
            this.pix = pix;
        }

        public VertexPositionColor[] DivideGrid(float x, float z, float width, float height, float c1, float c2, float c3, float c4)
        {
            this.buffer = new VertexPositionColor[] { };
            
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

                var tempBuffer = new[]{
                //below is looking from top to down    
                new VertexPositionColor(pos4, colorSet.GetColor(pos4)), // front part
                new VertexPositionColor(posMid, colorSet.GetColor(posMid)),
                new VertexPositionColor(pos3, colorSet.GetColor(pos3)),
                new VertexPositionColor(pos2, colorSet.GetColor(pos2)), // back part
                new VertexPositionColor(posMid, colorSet.GetColor(posMid)),
                new VertexPositionColor(pos1, colorSet.GetColor(pos1)),
                new VertexPositionColor(pos1, colorSet.GetColor(pos1)), // left part
                new VertexPositionColor(posMid, colorSet.GetColor(posMid)),
                new VertexPositionColor(pos4, colorSet.GetColor(pos4)),
                new VertexPositionColor(pos3, colorSet.GetColor(pos3)), // right part
                new VertexPositionColor(posMid, colorSet.GetColor(posMid)),
                new VertexPositionColor(pos2, colorSet.GetColor(pos2)),
                //below is looking from down to top    
                new VertexPositionColor(pos3, Color.OrangeRed), // front part
                new VertexPositionColor(posMid, Color.OrangeRed),
                new VertexPositionColor(pos4, Color.OrangeRed),
                new VertexPositionColor(pos1, Color.OrangeRed), // back part
                new VertexPositionColor(posMid, Color.OrangeRed),
                new VertexPositionColor(pos2, Color.OrangeRed),
                new VertexPositionColor(pos4, Color.OrangeRed), // left part
                new VertexPositionColor(posMid, Color.OrangeRed),
                new VertexPositionColor(pos1, Color.OrangeRed),
                new VertexPositionColor(pos2, Color.OrangeRed), // right part
                new VertexPositionColor(posMid, Color.OrangeRed),
                new VertexPositionColor(pos3, Color.OrangeRed),
                };

                List<VertexPositionColor> bufferList = this.buffer.ToList();
                for (int i = 0; i <= tempBuffer.Length - 1; i++)
                {
                    bufferList.Add(tempBuffer[i]);
                }
                this.buffer = bufferList.ToArray();
                tempBuffer = null;
            };

            return buffer;
        }
        //Randomly displaces color value for midpoint depending on size
        //of grid piece.
        float Displace(float num)
        {

            Random rd = new Random();
            float max = num / (float)(landscapeWidth + landscapeHeight) * 4f;
            float h = ((float)rd.NextDouble(0, 1) - 0.5f) * max;
            if (num == landscapeWidth)
            {
                baseline += h;
                colorSet.setBaseline(baseline);

            }
            return h;//
        }
        //Returns a color based on the height of pos
     
        }
   
}
