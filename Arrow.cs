﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    using System.Diagnostics;
    class Arrow : ColoredGameObject
    {
        public double ywave = 0.0f;
        public  double times = 0.0;

        public Arrow(Project1Game game)
        {
            
            model = game.Content.Load<Model>("arrow6");
            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                View = game.camera.View,
                Projection = game.camera.Projection,
                World = Matrix.Scaling(0.003f),
                VertexColorEnabled = true
            };

            BasicEffect.EnableDefaultLighting(model,true);
            inputLayout = VertexInputLayout.FromBuffer(0, vertices);

            this.game = game;
            pos = new SharpDX.Vector3(0, 0, 0);
        }

        public override void Update(SharpDX.Toolkit.GameTime gametime)
        {

            times += 0.1; 
            ywave = 0.05 * Math.Sin(times);
            
        }

        public override void Draw(SharpDX.Toolkit.GameTime gametime)
        {
            //model.Draw(game.GraphicsDevice, basicEffect.World, basicEffect.View, basicEffect.Projection);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // effect.EnableDefaultLighting();
                    effect.LightingEnabled = true; // Turn on the lighting subsystem.

                    effect.DirectionalLight0.DiffuseColor = new Vector3(0f, 1f, 0f); // a reddish light
                    effect.DirectionalLight0.Direction = new Vector3(pos.X +100, pos.Y+500, pos.Z+ 500);  // coming along the x-axis
                    effect.DirectionalLight0.SpecularColor = new Vector3(0, 0, 0); // with green highlights

                    effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f); // Add some overall ambient light.
                    // effect.EmissiveColor = new Vector3(1, 0, 0); // Sets some strange emmissive lighting.  This just looks weird.

                    effect.World = this.basicEffect.World;
                    effect.View = this.basicEffect.View;
                    effect.Projection = this.basicEffect.Projection;

                    //     effect.TextureEnabled = true;
                    //     effect.Texture = texture; 
                }

                mesh.Draw(game.GraphicsDevice);
            }
        }
    }
}

