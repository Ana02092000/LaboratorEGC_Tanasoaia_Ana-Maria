using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tema
{
    class Fereastra : GameWindow
    {
        KeyboardState copie_tastatura;
        Randomizer _r;
        private Cub primulCub;
        private readonly Camera cam;

        public Fereastra() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            _r = new Randomizer();
            primulCub = new Cub();
            cam = new Camera();

            Afiseaza_meniu_help();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //setare culoare de fundal
            GL.ClearColor(Color.LightSkyBlue);

            //setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //setare perspectiva
            //definire
            Matrix4 perspect = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            //activare
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspect);

            /*//setare camera
            //definire
            Matrix4 camera = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            //activare(incarcare)
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);*/
            cam.SetCamera();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //LOGIC CODE

            KeyboardState tastatura = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            
            /*if(mouse.IsButtonDown(MouseButton.Left))
            {
                GL.Rotate(10, 0, 7.5, 0);
            }

            if (mouse.IsButtonDown(MouseButton.Right))
            {
                GL.Rotate(10, 7.5, 0, 7.5);
            }*/


            //miscare cub dupa axe 
            if (tastatura[Key.Left])
            {
                GL.Rotate(10, 7.5, 0, 0);
            }

            if (tastatura[Key.Right])
            {
                GL.Rotate(10, 0, 7.5, 0);
            }

            if (tastatura[Key.Up])
            {
                GL.Rotate(10, 0, 0, 7.5);
            }

            if (tastatura[Key.Escape])
            {
                Exit();
            }

            if(tastatura[Key.H] && !copie_tastatura[Key.H])
            {
                Afiseaza_meniu_help();
            }

            if(tastatura[Key.B] && ! copie_tastatura[Key.B])
            {
                GL.ClearColor(_r.FurnizareCuloareAleatorie());
            }

            if (tastatura[Key.X] && !copie_tastatura[Key.X])
            {
                primulCub.SchimbareCuloare(_r);
            }

            // camera control (isometric mode)
            if (tastatura[Key.W])
            {
                cam.MoveForward();
            }
            if (tastatura[Key.S])
            {
                cam.MoveBackward();
            }
            if (tastatura[Key.A])
            {
                cam.MoveLeft();
            }
            if (tastatura[Key.D])
            {
                cam.MoveRight();
            }
            if (tastatura[Key.Q])
            {
                cam.MoveUp();
            }
            if (tastatura[Key.E])
            {
                cam.MoveDown();
            }

            copie_tastatura = tastatura;
            //END LOGIC CODE
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //RANDER CODE
            primulCub.Desenare();
            DrawAxes();

            //END RANDER CODE

            SwapBuffers();
        }

        private void DrawAxes()
        {
            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(75, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 75, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 75);
            GL.End();
        }

        private void Afiseaza_meniu_help()
        {
            Console.WriteLine("     HELP     ");
            Console.WriteLine("______________");
            Console.WriteLine("ESC - iesire din program");
            Console.WriteLine("H - afisare meniu help");
            Console.WriteLine("B - schimbare culoare fundal");
            Console.WriteLine("X - schimbare culoare cub");
            Console.WriteLine("sageata stanga - rotire dupa axa OX");
            Console.WriteLine("sageata dreapta - rotire dupa axa OY");
            Console.WriteLine("sageata sus - rotire dupa axa OZ");
        }
    }
}
