﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;
using System.Threading;

namespace Inf3Project
{
    /// <summary>
    /// This is a very, very basic GUI. It communicates with any IBackend, takes the map and existing entities and renders them in a generic fashion.
    /// The space will be devided evenly among the ITiles of a map. That means: bigger maps will result in very tiny cells on the GUI.
    /// No scrolling or any fancy mechanisms.
    /// Entities will also be displayed in a generic way: players are rendered in yellow, dragons are red. No IDs, names or whatsoever.
    /// It also offers basic functionality to communicate with the backend to input commands via the chat. So you can do some testing by manually entering commands like "/get:map".
    /// The GUI also consists of a chat-window, featuring incoming chat-messages and a input-box, to send messages to the IBackend (which have to be handled there!).
    /// Pressing ENTER sends the text in the input-box and also switches between chat-mode and walk-mode. In walk-mode, pressing WASD causes the frontend to send move-commands to the IBackend.
    /// As you can see, this is just rudimentary functionality and rendering and you might wish (and are invited) to extend the class, modify the existing sourcecode or even write your very own implementation to have a more appealing GUI that fits your needs.
    /// 
    /// To get this to work, you will have to let your backend implemented the provided IBackend-interface (and of course the other provided interfaces where needed). Then 
    /// </summary>
    public partial class DefaultGui : Form
    {
        private IBackend ba;
        private GUIManager m;
        private MapCell mapcell;
        private Int32 xPos;
        private Int32 yPos;
        public delegate void AddListItem();
        public AddListItem myDelegate;
        public bool isLocked = false;
        delegate void setTextCallback(string text);
        private String chatProcess = "";

        public DefaultGui(IBackend backend) : base()
        {
         
            if (backend == null)
            {
                throw new ArgumentNullException("invalid value for 'backend': null");
            }
            this.ba = backend;
            myDelegate = new AddListItem(repaint);
            InitializeComponent();
            // we usually don't have a console in a form-project. This enables us to see debug-output anyway
            AllocConsole();
            this.board.Paint += board_PaintMap;
            this.board.Paint += board_PaintEntities;
            this.chatInput.KeyPress += chat_KeyPress;
            this.board.KeyPress += board_KeyPress; 

            int map_XKoord = backend.getTilesOfMap()[0].Length;
            int map_YKoord = backend.getTilesOfMap().Length;
           
        }

        public void setLock(bool locked)
        {
            this.isLocked = locked;
        }
       
        protected override CreateParams CreateParams
        {
        	get 
	        { 
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on ES_EX_COMPOSITED
	    	    return cp;
	        }
        }
        
        /// <summary>
        /// Handles keypresses the chatInput-field receives.
        /// Having ENTER pressed, causes the field to be emptied and have the trimmed text in the field sent to the backend.
        /// If the input starts with "/", it will be handled as command (like ask:mv:up and such).
        /// All other messages will be treated as chat-messages and have to be wrapped by the backend as such.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public void repaint()
        {
            this.board.Refresh();
        }

        private void Board_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Size tileSize = this.getTileSize();
                int x = e.Location.X / tileSize.Width;
                int y = e.Location.Y / tileSize.Height;

                ba.sendCommand("get:myid");

                MapCell target = this.ba.getMapCell(x, y);
                this.ba.pathfinder(this.ba.getMyPlayerPos(), target);
            }
        } 

        private void chat_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter) 
            {
                    string input = this.chatInput.Text.Trim();
                    this.chatInput.Text = "";
                    
                    if (input != "")
                    {
                        if (input.StartsWith("/"))
                        {
                            input = input.Substring(1, input.Length-1);
                            this.ba.sendCommand(input);
                        }
                        else
                        {
                            this.ba.sendChat(input); 
                        }
                    }
                    this.board.Focus();
            }
            
        }

        /// <summary>
        /// Handles keypresses when the board is focused. This is whenever the chatinput is NOT focused.
        /// Will handle WASD as triggers for the movement.
        /// A: left
        /// W: up
        /// S: down
        /// D: right
        /// Pressing ENTER causes the chatinput to be focused again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void board_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (isLocked == false)
            {
                // fall-through-cases for capital letters
                switch (e.KeyChar)
                {
                    case (char)Keys.Enter:
                        this.chatInput.Focus();
                        break;
                    case 'a':
                    case 'A':
                        this.ba.moveLeft();
                        break;
                    case 'd':
                    case 'D':
                        this.ba.moveRight();
                        break;
                    case 'w':
                    case 'W':
                        this.ba.moveUp();
                        break;
                    case 's':
                    case 'S':
                        this.ba.moveDown();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pathwalking is currently finding path");
            }
        }

        /// <summary>
        /// Handler to paint the tiles in the map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void board_PaintMap(object sender, System.Windows.Forms.PaintEventArgs e) {
          
                Size tileSize = this.getTileSize();
                ITile[][] cells = this.ba.getTilesOfMap();
                // validity checked beforehand in getTileSize
                Debug.Assert(cells != null);
                BufferedGraphics buffer = BufferedGraphicsManager.Current.Allocate(this.board.CreateGraphics(), this.board.DisplayRectangle);
                Graphics g = this.CreateGraphics();
                for (int x = 0; x < cells.Length; x++)
                {
                    for (int y = 0; y < cells[x].Length; y++)
                    {
                        this.drawMapTile(buffer.Graphics, cells[x][y], x * tileSize.Width, y * tileSize.Height, tileSize.Width, tileSize.Height);
                    }
                }
                Player tmp = ba.getMyPlayer();
                labelName.Text = tmp.getDesc().ToString();
                labelPoints.Text = tmp.getPoints().ToString();
                labelBusy.Text = tmp.getBusy().ToString();
                labelX.Text = tmp.getXPosition().ToString();
                labelY.Text = tmp.getYPosition().ToString();
                buffer.Render(); 
        }

        /// <summary>
        /// Handler to paint all entities Dragons first, then the Players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void board_PaintEntities(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            List<IPositionable> dragons = this.ba.getDragons();
            foreach (IPositionable dragon in dragons)
            {
                this.drawDragon(e.Graphics, dragon);
            }
            List<IPositionable> players = this.ba.getPlayers();
            foreach (IPositionable player in players)
            {
                this.drawPlayer(e.Graphics, player);   
            }
          
        }

        /// <summary>
        /// Draws a tile of the map on a graphics object.
        /// By default, it will draw a rectangle (colour will be dependent of the attributes of the tile).
        /// WATER: blue
        /// FOREST: dark green
        /// HUNTABLE: light green
        /// UNWALKABLE: grey
        /// else: peach
        /// It will have a black 1px border.
        /// </summary>
        /// <param name="g">the graphics-object to draw on</param>
        /// <param name="tile">the tile-object that implements ITile</param>
        /// <param name="absX">absolute pixel x-position of the upper left corner of the tile, relative to the upper left corner of the graphics-object</param>
        /// <param name="absY">absolute pixel y-position of the upper left corner of the tile, relative to the upper left corner of the graphics-object</param>
        /// <param name="width">width of the tile in pixels</param>
        /// <param name="height">height of the tile in pixels</param>
        protected void drawMapTile(Graphics g, ITile tile, int absX, int absY, int width, int height)
        {
            TextureBrush tb;
    
            if (tile.isForest())
            {
                if (tile.isHuntable())
                {
                    Bitmap myBitmap = new Bitmap(Application.StartupPath + @"\..\..\Resources\grass.bmp");
                    tb = new TextureBrush(myBitmap);
                    g.FillRectangle(tb, absX, absY, width, height);
                }
                else
                {
                    Bitmap myBitmap = new Bitmap(Application.StartupPath + @"\..\..\Resources\forest.bmp");
                    tb = new TextureBrush(myBitmap);
                    g.FillRectangle(tb, absX, absY, width, height);
                }
            }
            else if (tile.isWater())
            {
                Bitmap myBitmap = new Bitmap(Application.StartupPath + @"\..\..\Resources\water.bmp");
                tb = new TextureBrush(myBitmap);
                g.FillRectangle(tb, absX, absY, width, height);
            }
            else if (!tile.isWalkable())
            {
                Bitmap myBitmap = new Bitmap(Application.StartupPath + @"\..\..\Resources\cement.bmp");
                tb = new TextureBrush(myBitmap);
                g.FillRectangle(tb, absX, absY, width, height);
            }
            else
            {
                Bitmap myBitmap = new Bitmap(Application.StartupPath + @"\..\..\Resources\desert.bmp");
                tb = new TextureBrush(myBitmap);
                g.FillRectangle(tb, absX, absY, width, height);
            }

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), new Rectangle(absX, absY, width, height));
        }

        /// <summary>
        /// Draws a player on the graphics.
        /// By default, players will be represented by a centered dark-yellow rectangle that takes up half of the cells size.
        /// </summary>
        /// <param name="g">the graphics-object to draw on</param>
        /// <param name="player">the player to draw</param>
        protected void drawPlayer(Graphics g, IPositionable player)
        {
            int[] tmp = ba.getMyPos();
            if(tmp[0] == player.getXPosition() && tmp[1] == player.getYPosition()){
                Size tileSize = this.getTileSize();
                g.FillRectangle(new SolidBrush(Color.DarkGoldenrod),
                    player.getXPosition() * tileSize.Width + tileSize.Width / 2 - tileSize.Width / 4,
                    player.getYPosition() * tileSize.Height + tileSize.Height / 2 - tileSize.Height / 4,
                    tileSize.Width / 2,
                    tileSize.Height / 2);
            }else{
                Size tileSize = this.getTileSize();
                g.FillRectangle(new SolidBrush(Color.DarkCyan),
                    player.getXPosition() * tileSize.Width + tileSize.Width / 2 - tileSize.Width / 4,
                    player.getYPosition() * tileSize.Height + tileSize.Height / 2 - tileSize.Height / 4,
                    tileSize.Width / 2,
                    tileSize.Height / 2);
            }
        }

        /// <summary>
        /// Draws a dragon on the graphics.
        /// By default, dragons will be represented by a centered red rectangle that takes up half of the cells size.
        /// </summary>
        /// <param name="g">the graphics-object to draw on</param>
        /// <param name="dragon">the dragon to draw</param>
        protected void drawDragon(Graphics g, IPositionable dragon)
        {
            Size tileSize = this.getTileSize();
            g.FillRectangle(new SolidBrush(Color.DarkRed),
                dragon.getXPosition() * tileSize.Width + tileSize.Width / 2 - tileSize.Width / 4,
                dragon.getYPosition() * tileSize.Height + tileSize.Height / 2 - tileSize.Height / 4,
                tileSize.Width / 2,
                tileSize.Height / 2);
        }

        /// <summary>
        /// Devides the space of the board-panel equally among the tiles of the map.
        /// For intance, if the board is 100px wide and the map consists of 5 cells in y-direction
        /// each tile will have a width of 100px/5 = 20px. Same for the height.
        /// </summary>
        /// <returns>the size of one tile to fit the whole map on the board</returns>
        protected Size getTileSize()
        {
            IPositionable[][] cells = this.ba.getTilesOfMap();
            if (cells == null)
            {
                throw new ArgumentNullException("backend returned null as map");
            }
            if (cells.Length == 0)
            {
                throw new IndexOutOfRangeException("outer dimension of the retrieved map has length 0");
            }
            if (cells[0].Length == 0)
            {
                throw new IndexOutOfRangeException("inner dimension of the retrieved map has length 0");
            }
            int cellWidth = this.board.Size.Width / cells.Length;
            int cellHeight = this.board.Size.Height / cells[0].Length;
            return new Size(cellWidth, cellHeight);
        }

        /// <summary>
        /// Appends a chat-message to the chat-window as a new line. Can be called from the backend or other participants to display incoming chat-messages.
        /// Messages will always be displays in the fasion of:
        /// sender: message
        /// </summary>
        /// <param name="sender">the source of the message</param>
        /// <param name="message">the message itself</param>
 
        //public void sendChatMessage()
        //{
        //    this.Invoke(message);
        //    m.sendChatMessage();
        //}

        public void appendChatMessage(String sender, String message)
        {
            this.chatProcess += sender + ": " + message + "\n";
            this.setChatText(chatProcess);
        }

        private void setChatText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.chatWindow.InvokeRequired)
            {
                setTextCallback d = new setTextCallback(setChatText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.chatWindow.Text = text;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = this.chatInput.Text.Trim();
            this.chatInput.Text = "";

            if (input != "")
            {
                if (input.StartsWith("/"))
                {
                    input = input.Substring(1, input.Length - 1);
                    this.ba.sendCommand(input);
                }
                else
                {
                    this.ba.sendChat(input);
                }
            }
            this.board.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Player tmp = ba.getMyPlayer();
            setChatText(tmp.getDesc().ToString() + " refuses the connection...  *QUIT");
            ba.sendCommand("ask:bye");
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
