using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PhysicsTest
{
    public class DrawableShapes : List<DrawableShape>
    {
        private List<DrawableShape> refer;
        public DrawableShapes() : base()
        {
            refer = this;
        }
        public void DrawAll(SpriteBatch sp)
        {
            foreach (DrawableShape ds in this)
            {
                ds.Draw(sp, Color.White, 2f);
            }

        }


    }

}
