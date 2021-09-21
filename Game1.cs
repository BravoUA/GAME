using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Diplom
{
    class Input
    {

        static MouseState mouseState;
        static MouseState mouseOldState;
        static KeyboardState oldKeyboardState;
        static KeyboardState currentKeyboardState;


        static Input()
        {
        }

        internal static void Update(GameTime gameTime)
        {

            mouseOldState = mouseState;
            mouseState = Mouse.GetState();
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
        internal static bool IsMouseLeftDown()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }
        internal static bool IsMouseLeftClick()
        {
            return IsMouseLeftDown() && mouseOldState.LeftButton == ButtonState.Released;
        }

        internal static bool IsMouseRightDown()
        {
            return mouseState.RightButton == ButtonState.Pressed;
        }
        internal static bool IsMouseRightClick()
        {
            return IsMouseRightDown() && mouseOldState.RightButton == ButtonState.Released;
        }
        internal static bool isMouseReleased()
        {
            return (mouseState.LeftButton == ButtonState.Released);
        }
        internal static Point GetMousePositionToPoint()
        {
            return new Point(mouseState.X, mouseState.Y);
        }
        internal static Point GetOldMousePositionToPoint()
        {
            return new Point(mouseOldState.X, mouseOldState.Y);
        }
        internal static bool IsMouseLeftUp()
        {
            return isMouseReleased() && mouseOldState.LeftButton == ButtonState.Pressed;
        }
        internal static string KeysInput(string textString)
        {

            bool shift = oldKeyboardState.IsKeyDown(Keys.LeftShift) || oldKeyboardState.IsKeyDown(Keys.RightShift);

            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {

                if (oldKeyboardState.IsKeyUp(key))
                {
                    if (key == Keys.Back && textString != null && textString.Length != 0) // overflows
                        textString = textString.Remove(textString.Length - 1, 1);
                    else
                        if (key == Keys.Space)
                            textString = textString.Insert(textString.Length, " ");
                        else if (key == Keys.D0)
                        {
                            textString = textString.Insert(textString.Length, "0");
                        }
                        else if (key == Keys.D1)
                        {
                            textString = textString.Insert(textString.Length, "1");
                        }
                        else if (key == Keys.D2)
                        {
                            textString = textString.Insert(textString.Length, "2");
                        }
                        else if (key == Keys.D3)
                        {
                            textString = textString.Insert(textString.Length, "3");
                        }
                        else if (key == Keys.D4)
                        {
                            textString = textString.Insert(textString.Length, "4");
                        }
                        else if (key == Keys.D5)
                        {
                            textString = textString.Insert(textString.Length, "5");
                        }
                        else if (key == Keys.D6)
                        {
                            textString = textString.Insert(textString.Length, "6");
                        }
                        else if (key == Keys.D7)
                        {
                            textString = textString.Insert(textString.Length, "7");
                        }
                        else if (key == Keys.D8)
                        {
                            textString = textString.Insert(textString.Length, "8");
                        }
                        else if (key == Keys.D9)
                        {
                            textString = textString.Insert(textString.Length, "9");
                        }
                        else if (key == Keys.OemPeriod)
                        {
                            textString = textString.Insert(textString.Length, ".");
                        }
                        else if (key == Keys.OemSemicolon)
                        {
                            textString = textString.Insert(textString.Length, ":");
                        }


                }

            }
            return textString;
        }
        internal static bool KeysIt()
        {
            bool keyclick = false;


            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {

                if (oldKeyboardState.IsKeyUp(key))
                {

                    if (key == Keys.Space)
                        keyclick = true;

                }

            }
            return keyclick;
        }
    }
    class MTR  
    {
        public SpriteFont font;
        
        List<List<Vector2>> rectab = new List<List<Vector2>>();
        public List<List<double>> tab = new List<List<double>>();
        private List<double> Bmax = new List<double>();
        private List<double> Amin = new List<double>();
        private List<double> Fx = new List<double>();
        private List<double> x = new List<double>();
        private List<double> y = new List<double>();
        private List<double> p = new List<double>();
        private List<double> q = new List<double>();
        private List<double> FreeC = new List<double>();
        private List<double> Fx1 = new List<double>();
        private List<List<int>> basesF = new List<List<int>>();
        private List<List<string>> X1 = new List<List<string>>();
        private int amin = 0, bmax = 0, g = 0, maxFx = 0, nr = 0, nc = 0, iteration = 0;
        private double maxFxCof = 0, maxFxResul = 100, FX0 = 0;
        private int minspro = 0;
        private Random items = new Random();
        private int a = 0;
        private List<double> b2 = new List<double>();
        private List<double> Fx2 = new List<double>();
        private List<int> bases = new List<int>();

        public int strategX = 0;
    
        static MTR() { }
        public void GET(List<List<double>> FirstTAB, List<double> FirstFx, List<double> FirstFreeC)
        {
            tab.Clear();
            Fx.Clear();
            FreeC.Clear();
            for (int i = 0; i < FirstTAB.Count; i++)
            {
                tab.Add(new List<double>());
                for (int j = 0; j < FirstTAB.Count; j++)
                {
                    tab[i].Add(FirstTAB[i][j]);
                }
            }
            for (int i = 0; i < FirstFx.Count; i++)
            {
               Fx.Add(FirstFx[i]);
              FreeC.Add(FirstFreeC[i]);
                
            } 
        }
        public void SumpMet()
        {
            Fx1.Clear();
            amin = 0;
            bmax = 0;
            Bmax.Clear();
            Amin.Clear();
            bases.Clear();
            x.Clear();
            y.Clear();
            iteration = 0;

            for (int i = 0; i < tab.Count; i++)
            {
                amin = (int)tab[i][0];
                bmax = (int)tab[0][i]; 
                for (int j = 0; j < tab.Count; j++)
                {
                    if (amin > tab[i][j])
                    {
                        amin = (int)tab[i][j];
                    }
                    if (bmax < tab[j][i])
                    {
                        bmax = (int)tab[j][i];
                    }
                }
                Amin.Add(amin);
                Bmax.Add(bmax);
            }

            bmax = (int)Bmax[0];
            amin = (int)Amin[0];
            for (int k = 0; k < Amin.Count; k++)
            {

                if (Amin[k] > amin)
                {
                    amin = (int)Amin[k];
                }
            }
            for (int k = 0; k < Bmax.Count; k++)
            {
                if (Bmax[k] < bmax)
                {
                    bmax = (int)Bmax[k];
                }
            }
            if (amin == bmax)
            {
                Goback();
            }
            else
            {
                int freecof = tab.Count;


                for (int i = 0; i < tab.Count; i++)
                {
                    for (int j = 0; j < tab[i].Count; j++)
                    {
                        if (minspro > tab[i][j])
                        {
                            minspro = (int)tab[i][j];
                        }
                    }
                }
                for (int i = 0; i < tab.Count; i++)
                {
                    for (int j = 0; j < tab[i].Count; j++)
                    {
                        tab[i][j] = tab[i][j] + Math.Abs((double)minspro);
                    }
                }


                for (int i = 0; i < tab.Count; i++)
                {
                    for (int j = 0; j < tab.Count; j++)
                    {
                        if (j == i) { tab[i].Add(1); } else { tab[i].Add(0); }
                    }
                }
                int Fxcount = tab[0].Count - Fx.Count;
                for (int i = 0; i < Fxcount; i++)
                {
                    Fx.Add(0);
                }
                bases.Clear();
                for (int i = 0; i < tab[0].Count; i++)
                {
                    int cof1 = 0;
                    int cof2 = 0;
                    for (int j = 0; j < tab.Count; j++)
                    {
                        if (tab[j][i] == 0)
                        {
                            cof1++;
                        }
                        if (tab[j][i] == 1)
                        {
                            cof2++;
                        }
                        if (cof1 == (tab.Count - 1) && cof2 == 1)
                        {
                            bases.Add(i + 1);
                        }

                    }
                }
            }
            MinMax(tab, Fx, FreeC);
        }
        public void Goback()
        {
            tab.Clear();
            FreeC.Clear();
            Fx.Clear();
            Fx1.Clear();
            amin = 0;
            bmax = 0;
            Bmax.Clear();
            Amin.Clear();
            bases.Clear();
            SumpMet();
        }
        public void MinMax(List<List<double>> tab, List<double> Fx, List<double> FREEC)
        {

            bases.Clear();
            for (int i = 0; i < tab[0].Count; i++)
            {
                int cof1 = 0;
                int cof2 = 0;
                for (int j = 0; j < tab.Count; j++)
                {
                    if (tab[j][i] == 0)
                    {
                        cof1++;
                    }
                    if (tab[j][i] == 1)
                    {
                        cof2++;
                    }
                    if (cof1 == (tab.Count - 1) && cof2 == 1)
                    {
                        bases.Add(i + 1);
                    }

                }
            }

            Fx1.Clear();
            double ex = 0;
            for (int i = 0; i < tab[0].Count; i++)
            {
                for (int j = 0; j < tab.Count; j++)
                {
                    ex = ex + (Fx[bases[j] - 1] * tab[j][i]);
                }
                ex = ex - Fx[i];
                Fx1.Add(ex);
                ex = 0;
                if (i == (tab[0].Count - 1))
                {
                    for (int j = 0; j < tab.Count; j++)
                    {
                        ex = ex + (Fx[bases[j] - 1] * FreeC[j]);
                    }
                    Fx1.Add(ex);
                }
            }
            MinMax2(tab, Fx1, FreeC);
        }
        public void MinMax2(List<List<double>> tab, List<double> Fx, List<double> FREEC)
        {
            maxFxCof = 0;
            maxFx = 0;
            for (int i = 0; i < Fx.Count - 1; i++)
            {
                for (int j = 0; j < tab.Count; j++)
                {
                    if (tab[j][i] > 0)
                    {
                        if (maxFxCof < Fx1[i])
                        {
                            if (maxFxCof != Fx1[i])
                            {
                                maxFx = i;
                                maxFxCof = Fx1[i];
                            }
                        }
                    }
                }
            }
            if (maxFx == 0 && maxFxCof == 0)
            {
                bases.Clear();
                for (int i = 0; i < tab[0].Count; i++)
                {
                    int cof1 = 0;
                    int cof2 = 0;
                    for (int j = 0; j < tab.Count; j++)
                    {
                        if (tab[j][i] == 0)
                        {
                            cof1++;
                        }
                        if (tab[j][i] == 1)
                        {
                            cof2++;
                        }
                        if (cof1 == (tab.Count - 1) && cof2 == 1)
                        {
                            bases.Add(i + 1);
                        }
                    }
                }

                finish(tab,Fx1,FreeC);


            }
            else
            {
                nc = maxFx;
                maxFxCof = 0;
                maxFxResul = 100;
                for (int j = 0; j < FreeC.Count; j++)
                {
                    if ((double)tab[j][maxFx] > 0)
                    {
                        maxFxCof = FreeC[j] / tab[j][maxFx];
                        if (maxFxResul > maxFxCof && maxFxResul != 0)
                        {
                            maxFxResul = maxFxCof;
                            nr = j;
                        }
                    }
                }
                Gaus(tab, Fx1, FreeC, nr, nc);
            }
        }
        public void Gaus(List<List<double>> STAB, List<double> FX, List<double> FREEC, int nr, int nc)
        {
            iteration++;
            STAB.Add(new List<double>());
            for (int i = 0; i < FX.Count; i++)
            {
                STAB[STAB.Count - 1].Add(FX[i]);
            }
            for (int j = 0; j < FREEC.Count; j++)
            {
                STAB[j].Add(FREEC[j]);
            }
            double cof = 0;
            cof = (double)STAB[nr][nc];
            STAB[nr][nc] = STAB[nr][nc] / STAB[nr][nc];
            for (int i = 0; i < STAB[nr].Count; i++)
            {
                if (i != nc)
                {
                    STAB[nr][i] = STAB[nr][i] / cof;
                }
            }
            for (int i = 0; i < STAB.Count; i++)
            {
                if (i != nr)
                {
                    cof = (double)STAB[i][nc];

                    if (cof < 0) { cof = (double)Math.Abs(STAB[i][nc]); } else { cof = cof * (-1); }

                    for (int j = 0; j < STAB[i].Count; j++)
                    {
                        STAB[i][j] = (cof * STAB[nr][j]) + STAB[i][j];
                    }
                }
            }
            for (int i = 0; i < STAB[STAB.Count - 1].Count; i++)
            {
                FX[i] = STAB[STAB.Count - 1][i];
            }
            STAB.Remove(STAB[STAB.Count - 1]);

            for (int i = 0; i < FREEC.Count; i++)
            {
                FREEC[i] = 0;
            }
            for (int i = 0; i < STAB.Count; i++)
            {
                FREEC[i] = STAB[i][STAB[i].Count - 1];
            }
            for (int i = 0; i < STAB.Count; i++)
            {
                STAB[i].RemoveAt(STAB[i].Count - 1);
            }
            List<int> bases = new List<int>(); ;

            for (int i = 0; i < STAB[0].Count; i++)
            {
                int cof1 = 0;
                int cof2 = 0;
                for (int j = 0; j < STAB.Count; j++)
                {
                    if (STAB[j][i] == 0)
                    {
                        cof1++;
                    }
                    if (STAB[j][i] == 1)
                    {
                        cof2++;
                    }
                    if (cof1 == (STAB.Count - 1) && cof2 == 1)
                    {
                        bases.Add(i + 1);
                    }
                }
            }
            MinMax2(STAB, FX, FREEC);
        }
        public void finish(List<List<double>> tab, List<double> Fx1, List<double> FREEC)
        {
            strategX = 0;
            basesF.Clear();
            basesF.Add(new List<int>());
            basesF.Add(new List<int>());
            for (int i = 0; i < tab.Count; i++)
            {
                int cof1 = 0;
                int cof2 = 0;
                int basepos = 0;
                for (int j = 0; j < tab.Count; j++)
                {
                    if (tab[j][i] == 0)
                    {
                        cof1++;
                    }
                    if (tab[j][i] == 1)
                    {
                        cof2++;
                        basepos = j;
                    }
                    if (cof1 == (tab.Count - 1) && cof2 == 1)
                    {
                        basesF[0].Add(i + 1);

                        x.Add(FREEC[basepos]);
                    }
                    if (j + 1 == tab.Count && cof1 != (tab.Count - 1) && cof2 != 1)
                    {
                        x.Add(0);
                    }
                }
            }
            double V = 0;
            for (int i = 0; i < tab.Count; i++)
            {
                y.Add(Fx1[x.Count + i]);
            }
            double F_X = 0, F_Y = 0;
            for (int i = 0; i < tab.Count; i++)
            {
                F_X = F_X + (x[i] * 1);
                F_Y = F_Y + (y[i] * 1);
            }
            F_X = F_X * -1;
            if (Math.Round(F_X,5)  == Math.Round(F_Y,5))
            {
                V = 1 / F_X;
                for (int i = 0; i < tab.Count; i++)
                {
                    p.Add(V * x[i]);
                    q.Add(V * y[i]);
                }
                V = V - minspro;
            
            double choiseXstrateg=p[0];

            for (int i = 1; i < tab.Count; i++)
            {
                if (Math.Abs(choiseXstrateg) < Math.Abs(p[i]))
                {
                    choiseXstrateg = p[i];
                    strategX=i;
                }
            }
           }
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        List<Texture2D> Kartu1 = new List<Texture2D>();
        List<Texture2D> Kartu2 = new List<Texture2D>();

        List<Texture2D> Kartu1_1 = new List<Texture2D>();
        List<Texture2D> Kartu2_2 = new List<Texture2D>();

        List<Texture2D> fon = new List<Texture2D>();
        List<Texture2D> top_fon = new List<Texture2D>();
        List<Texture2D> back_fon = new List<Texture2D>();
        List<Rectangle> rec = new List<Rectangle>();
        List<Rectangle> rec1 = new List<Rectangle>();
        List<Rectangle> rec_1 = new List<Rectangle>();
        List<Rectangle> rec1_1 = new List<Rectangle>();
        public int Gemepoint_A_Gamer = 0;
        int Gemepoint_B_Gamer = 0;
        List<List<double>> tabF = new List<List<double>>();
        List<double> Fx2f = new List<double>();
        List<double> FreeC2c = new List<double>();
     
        List<List<Vector2>> rectab = new List<List<Vector2>>();
        public bool get = true;
        public int cre = 0;
        Random items = new Random();
        int a = 0, XX = 0, YY= 0;
 
       
       
        SpriteFont font;
      
        MTR mtr = new MTR();
        int poin = 0;
        int gamerA = 0;
        int lastpoint = 555;
        int lastgamerA = 555;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.IsFullScreen = false;
        }
        protected override void Initialize()
        {
            
            IsMouseVisible = true;
            base.Initialize();
           
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
          //  font = Content.Load<SpriteFont>("princeofpersia");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SpriteFont1");
            fon.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\fon1.jpg")));
            mtr.font = Content.Load<SpriteFont>("SpriteFont1");
            font = Content.Load<SpriteFont>("SpriteFont1");
            top_fon.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\topfon.jpg")));
            back_fon.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\backfon.jpg")));
  
              
            
          
          
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {

            Input.Update(gameTime);
            if (IsActive)
            {
                
            if (Input.KeysIt())
            {
                gener();
            }


            for (int j = 0; j < tabF.Count; j++)
            {
                if (rec1[j].Contains(Input.GetMousePositionToPoint()))
            {

            if (Input.IsMouseLeftClick())
	            {
                   

                    for (int i = 0; i < tabF.Count; i++)
                    {
                        if (rec1[i].Contains(Input.GetMousePositionToPoint()) && Input.IsMouseLeftClick())
                        {
                           
                            poin = 0;
                            mtr.GET(tabF, Fx2f, FreeC2c);
                            mtr.SumpMet();
                           
                           // rec_1[mtr.strategX] = new Rectangle((graphics.PreferredBackBufferWidth - 40) - rec1[0].Width, (graphics.PreferredBackBufferHeight / 2) - (rec[0].Height / 2) - 50, 100, 140);
                           // rec1_1[i] = new Rectangle((graphics.PreferredBackBufferWidth - 40) - rec1[0].Width, (graphics.PreferredBackBufferHeight / 2) - rec1[0].Height / 2, 100, 140);
                            poin = i;
                            
                        }
                    }
                    

                        gamerA = mtr.strategX;
                        
                        
                        Gemepoint_B_Gamer = Gemepoint_B_Gamer + ((int)tabF[poin][gamerA]*(-1));
                        Gemepoint_A_Gamer = Gemepoint_A_Gamer + (int)tabF[poin][gamerA];
                        delet();
                       
                        
	            }
            }
               
            }
           
            if (Input.IsMouseRightClick())
            {
                cre = 4;
            }
                

            }
            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
           
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Begin();
            draw(spriteBatch, cre);

           

            
           
            
           // spriteBatch.DrawString(font, (rec[0].Contains(Input.GetMousePositionToPoint()) && Input.IsMouseLeftClick()).ToString(), new Vector2(200, 1), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void gener()
        {
            rec.Clear();
            rec1.Clear();
            Kartu1.Clear();
            Kartu2.Clear();
            Load();
                tabF.Clear();
                FreeC2c.Clear();
                Fx2f.Clear();
                Gemepoint_A_Gamer = 0;
                Gemepoint_B_Gamer = 0;
                for (int i = 0; i < 13; i++)
                {
                    rectab.Add(new List<Vector2>());
                    tabF.Add(new List<double>());
                    for (int j = 0; j < 13; j++)
                    {

                        a = items.Next(-10, 10);
                        tabF[i].Add(a);
                        if (a < 0)
                        {
                            if (a == -10)
                            { rectab[i].Add(new Vector2(140 - 25 + (84 * j), 90 + (50 * i))); }

                            else { rectab[i].Add(new Vector2(140 - 15 + (84 * j), 90 + (50 * i))); }
                        }
                        else { rectab[i].Add(new Vector2(140 + (84 * j), 90 + (50 * i))); }
                    }
                }
                for (int i = 0; i < tabF.Count; i++)
                {
                    Fx2f.Add(-1);
                    FreeC2c.Add(1);
                }

            
            cre = 1;

        }
        public void delet() 
        {
            for (int i = 0; i < tabF.Count; i++)
            {
                tabF[i].RemoveAt(gamerA);
            }
            Fx2f.RemoveAt(0);
            FreeC2c.RemoveAt(0);
            tabF.RemoveAt(poin);

            rec.RemoveAt(rec.Count-1);
            rec1.RemoveAt(rec1.Count-1);

            Kartu1.RemoveAt(gamerA);
            Kartu2.RemoveAt(poin);
            lastpoint = poin;
            lastgamerA = gamerA;
            if (tabF.Count==2)
            {
                cre = 3;
            }
        }
        public void Load() 
        {
         
            for (int j = 0; j < 13; j++)
            {
                Kartu1.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\0\\" + j + ".jpg")));
                Kartu1_1.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\0\\" + j + ".jpg")));
                rec.Add(new Rectangle(100 + (j * 85), 1, 80, 80));
                rec_1.Add(new Rectangle(0, 0, 0, 0));
            }
            for (int j = 13, i = 0; j < 26; j++)
            {
                Kartu2.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\0\\" + j + ".jpg")));
                Kartu2_2.Add(Texture2D.FromStream(GraphicsDevice, File.OpenRead("textures\\0\\" + j + ".jpg")));
                rec1.Add(new Rectangle(10, 85 + (i * 50), 80, 50));
                rec1_1.Add(new Rectangle(0, 0, 0, 0));
                i++;
            }
        }
        public void draw(SpriteBatch spriteBatch,int cre)
        {

            switch (cre)
            {
                case 0:
                    spriteBatch.Draw(fon[0], new Vector2(0, 0), Color.White);
                    spriteBatch.DrawString(font, "For The Start Game Please Enter Space", new Vector2((graphics.PreferredBackBufferWidth / 2) - 300, (graphics.PreferredBackBufferHeight / 2)), Color.White);
                break;

                case 1:
                    spriteBatch.Draw(fon[0], new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(top_fon[0], new Rectangle(0, 0, graphics.PreferredBackBufferWidth, 90), Color.White);
                    spriteBatch.Draw(back_fon[0], new Rectangle(0, 0, 100, graphics.PreferredBackBufferHeight), Color.White);
                    rectab.Clear();
                for (int i = 0; i < tabF.Count; i++)
                {
                    rectab.Add(new List<Vector2>());
                    for (int j = 0; j < tabF.Count; j++)
                    {
                        if (tabF[i][j] < 0)
                        {
                            if (tabF[i][j] == -10)
                            { rectab[i].Add(new Vector2(140 - 25 + (84 * j), 90 + (50 * i))); }
                            else { rectab[i].Add(new Vector2(140 - 15 + (84 * j), 90 + (50 * i))); }
                        }
                        else { rectab[i].Add(new Vector2(140 + (84 * j), 90 + (50 * i))); }
                    }
                }
                for (int i = 0; i < tabF.Count; i++)
                {
                    for (int j = 0; j < tabF.Count; j++)
                    {
                        spriteBatch.DrawString(font, Math.Round(tabF[i][j], 1).ToString(), rectab[i][j], Color.White);
                    }
                }
                     for (int i = 0; i < tabF.Count; i++)
            {
                spriteBatch.Draw(Kartu1[i], rec[i], Color.White);
                spriteBatch.Draw(Kartu1_1[i], rec_1[i], Color.White);

            }

            for (int i = 0; i < tabF.Count; i++)
            {
                 spriteBatch.Draw(Kartu2[i], rec1[i], Color.White);
                 spriteBatch.Draw(Kartu2_2[i], rec1_1[i], Color.White); 
            }
            spriteBatch.DrawString(font, "A." + Gemepoint_A_Gamer.ToString(), new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(font, "B." + Gemepoint_B_Gamer.ToString(), new Vector2(5, 30), Color.White);
                break;


                case 3:
                spriteBatch.Draw(fon[0], new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "GAME OVER", new Vector2((graphics.PreferredBackBufferWidth / 2) - 100, (graphics.PreferredBackBufferHeight / 2) - 50), Color.White);
                    spriteBatch.DrawString(font, "Points A player " + Gemepoint_A_Gamer.ToString(), new Vector2((graphics.PreferredBackBufferWidth / 2) - 180, (graphics.PreferredBackBufferHeight / 2)), Color.White);
                    spriteBatch.DrawString(font, "Points B player " + Gemepoint_B_Gamer.ToString(), new Vector2((graphics.PreferredBackBufferWidth / 2) - 180, (graphics.PreferredBackBufferHeight / 2)+50), Color.White);
                    spriteBatch.DrawString(font, "For The Start Game Please Enter Space", new Vector2((graphics.PreferredBackBufferWidth / 2) - 300, (graphics.PreferredBackBufferHeight / 2)+250), Color.White);
                    break;

                case 4:

                for (int i = 0; i < tabF.Count; i++)
                {
                    for (int j = 0; j < tabF.Count; j++)
                    {
                        spriteBatch.DrawString(font, Math.Round(mtr.tab[i][j], 1).ToString(), rectab[i][j], Color.White);
                    }
                }

                break;
            }
            
                
          
                
            
        }
    }
}
