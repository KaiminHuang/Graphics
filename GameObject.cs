﻿using System;
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
        public MyModel myModel;

        public BasicEffect basicEffect;
        public VertexInputLayout inputLayout;
        public Project1Game game;
        public Vector3 pos;
        public Model model;

        public abstract void Update(GameTime gametime);
        public abstract void Draw(GameTime gametime);

        public BasicEffect GetParamsFromModel()
        {
            if (myModel.modelType == ModelType.Colored)
            {
                basicEffect = new BasicEffect(game.GraphicsDevice)
                {
                    View = game.camera.View,
                    Projection = game.camera.Projection,
                    World = Matrix.Identity,
                    VertexColorEnabled = true
                };
            }
            else if (myModel.modelType == ModelType.Textured)
            {
                basicEffect = new BasicEffect(game.GraphicsDevice)
                {
                    View = game.camera.View,
                    Projection = game.camera.Projection,
                    World = Matrix.Identity,
                    Texture = myModel.Texture,
                    TextureEnabled = true,
                    VertexColorEnabled = false
                };
            }
            return basicEffect;
        }
    }
}
