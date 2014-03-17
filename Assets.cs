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
    public class Assets
    {
        Project1Game game;

        public Assets(Project1Game game)
        {
            this.game = game;
        }

        // Dictionary of currently loaded models.
        // New/existing models are loaded by calling GetModel(modelName, modelMaker).
        public Dictionary<String, MyModel> modelDict = new Dictionary<String, MyModel>();

        // Load a model from the model dictionary.
        // If the model name hasn't been loaded before then modelMaker will be called to generate the model.
        public delegate MyModel ModelMaker();
        public MyModel GetModel(String modelName, ModelMaker modelMaker)
        {
            if (!modelDict.ContainsKey(modelName))
            {
                modelDict[modelName] = modelMaker();
            }
            return modelDict[modelName];
        }

        // Create a cube with one texture for all faces.
        public MyModel CreateTexturedCube(String textureName, float size)
        {
            return CreateTexturedCube(textureName, new Vector3(size, size, size));
        }

        public VertexPositionColor[] CreateColoredTriangle(Vector3 size, Color color)
        {
            VertexPositionColor[] shapeArray = new VertexPositionColor[]{
            new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), color), // Front
            new VertexPositionColor(new Vector3(1.0f, 1.0f, -1.0f), color),
            new VertexPositionColor(new Vector3(-1.0f, 1.0f, -1.0f),color)
            };

            for (int i = 0; i < shapeArray.Length; i++)
            {
                shapeArray[i].Position.X *= size.X / 2;
                shapeArray[i].Position.Y *= size.Y / 2;
                shapeArray[i].Position.Z *= size.Z / 2;
            }

            return shapeArray;
        }


        public MyModel CreateTexturedCube(String texturePath, Vector3 size)
        {
            VertexPositionTexture[] shapeArray = new VertexPositionTexture[]{
            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f), new Vector2(1f, 2/3f)), // Front
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, -1.0f), new Vector2(3/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, -1.0f), new Vector2(1f, 1/3f)),

            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f), new Vector2(1f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, -1.0f), new Vector2(3/4f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, -1.0f), new Vector2(3/4f, 1/3f)),


            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, 1.0f), new Vector2(1/4f, 2/3f)), // BACK
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, 1.0f), new Vector2(1/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 1.0f), new Vector2(2/4f, 1/3f)),

            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, 1.0f), new Vector2(1/4f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 1.0f), new Vector2(2/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, 1.0f), new Vector2(2/4f, 2/3f)),


            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, -1.0f), new Vector2(1/4f, 0.0f)), // Top
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 1.0f), new Vector2(2/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, 1.0f), new Vector2(1/4f, 1/3f)),

            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, -1.0f), new Vector2(1/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, -1.0f), new Vector2(2/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 1.0f), new Vector2(2/4f, 0.0f)),


            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f), new Vector2(1/4f, 1.0f)), // Bottom
            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, 1.0f), new Vector2(1/4f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, 1.0f), new Vector2(2/4f, 2/3f)),

            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f), new Vector2(1/4f, 1.0f)),
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, 1.0f), new Vector2(2/4f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, -1.0f), new Vector2(2/4f, 1.0f)),


            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f), new Vector2(0.0f, 2/3f)), // Left
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, 1.0f), new Vector2(1/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, 1.0f), new Vector2(1/4f, 2/3f)),

            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f), new Vector2(0.0f, 2/3f)),
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, -1.0f), new Vector2(0.0f, 1/3f)),
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, 1.0f), new Vector2(1/4f, 1/3f)),


            new VertexPositionTexture(new Vector3(1.0f, -1.0f, -1.0f), new Vector2(3/4f, 2/3f)), // Right
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, 1.0f), new Vector2(2/4f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 1.0f), new Vector2(2/4f, 1/3f)),

            new VertexPositionTexture(new Vector3(1.0f, -1.0f, -1.0f), new Vector2(3/4f, 2/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 1.0f), new Vector2(2/4f, 1/3f)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, -1.0f), new Vector2(3/4f, 1/3f)),

            };

            for (int i = 0; i < shapeArray.Length; i++)
            {
                shapeArray[i].Position.X *= size.X / 2;
                shapeArray[i].Position.Y *= size.Y / 2;
                shapeArray[i].Position.Z *= size.Z / 2;
            }

            return new MyModel(game, shapeArray, texturePath);
        }
    }
}
