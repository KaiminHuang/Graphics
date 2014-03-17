using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    using System.Diagnostics;
    class CannonModel : ColoredGameObject
    {


        public CannonModel(Project1Game game)
        {

            model = game.Content.Load<Model>("Cannon");
            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                View = game.camera.View,
                Projection = game.camera.Projection,
                World = Matrix.Scaling(0.0003f) * Matrix.Translation(game.x0, game.y0 + 0.05f,game.z0),
                VertexColorEnabled = true
            };

            BasicEffect.EnableDefaultLighting(model,true);
            inputLayout = VertexInputLayout.FromBuffer(0, vertices);

            this.game = game;
            pos = new SharpDX.Vector3(-0.8f, 0f, 0.8f);
        }

        public override void Update(SharpDX.Toolkit.GameTime gametime)
        {
            
        }

        public override void Draw(SharpDX.Toolkit.GameTime gametime)
        {
           // model.Draw(game.GraphicsDevice, basicEffect.World, basicEffect.View, basicEffect.Projection);
                        foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // effect.EnableDefaultLighting();
                    effect.LightingEnabled = true; // Turn on the lighting subsystem.

                    effect.DirectionalLight0.DiffuseColor = new Vector3(0.0008f, 0.0008f, 0.0008f); // a reddish light
                    effect.DirectionalLight0.Direction = new Vector3(10000, 5000, 5000);  // coming along the x-axis
                    effect.DirectionalLight0.SpecularColor = new Vector3(0.8f, 0.8f, 0.8f); // with green highlights
                    effect.SpecularPower = 5;

                    effect.AmbientLightColor = new Vector3(0.1f, 0.1f, 0.1f); // Add some overall ambient light.
                    // effect.EmissiveColor = new Vector3(1, 0, 0); // Sets some strange emmissive lighting.  This just looks weird.
                /*    if (pos.Y > 50)
                    {
                        effect.FogEnabled = true;
                        effect.FogColor = Color.WhiteSmoke.ToVector3(); // For best results, ake this color whatever your background is.
                        effect.FogStart = 9.75f;
                        effect.FogEnd = 10.25f;
                    }*/
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
