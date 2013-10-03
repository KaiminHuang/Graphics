using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    abstract public class GameObject
    {
        public BasicEffect basicEffect;
        public VertexInputLayout inputLayout;
        public Project1Game game;
        public Vector3 pos;
        public MyModel myModel;

        public abstract void Update(GameTime gametime);
        public abstract void Draw(GameTime gametime);

        public void GetParamsFromModel()
        {

            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                View = game.camera.View,
                Projection = game.camera.Projection,
                World = Matrix.Identity,
                VertexColorEnabled = true
            };

        }
    }
}