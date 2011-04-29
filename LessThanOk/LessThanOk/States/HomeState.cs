﻿/*---------------------------------------------------------------------------*\
*                         LessThanOK Engine                                  *
*                                                                            *
*          Copyright (C) 2011-2012 by Robert Goetz, Anthony Lobono           *
*                                                                            *
*          authors:  Anthony LoBono (ajlobono@gmail.com)                     *
*                                                                            *
\*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*\
 *                                License                                    *
 *                                                                           *
 * This library is free software; you can redistribute it and/or modify it   *
 * under the terms of the MIT Liscense.                                      *
 *                                                                           *
 * This library is distributed in the hope that it will be useful, but       *
 * WITHOUT ANY WARRANTY; without even the implied warranty of                *
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                      *
 *                                                                           *
 * You should have received a copy of the MIT Liscense with this library, if *
 * not, visit http://www.opensource.org/licenses/mit-license.php.            *
 *                                                                           *
\*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*\
 *                            Class Overview                                 *
 *                                                                           *
 * HomeState is the state for choosing what to do. Create Game, Joing Game,  *
 * and Replay Game.                                                          *
 *                                                                           *
\*---------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LessThanOk.Input;
using LessThanOk.Input.Events;
using LessThanOk.UI;
using LessThanOk.UI.Frames;
using LessThanOk.UI.Frames.UIElements;
using LessThanOk.UI.Events;
using Microsoft.Xna.Framework.Content;

namespace LessThanOk.States
{
    class HomeState : State
    {
        /// <summary>
        /// Contructor for HomeState.
        /// </summary>
        /// <param name="frame">Frame for hooking up User Interface Events.</param>
        public HomeState(Frame frame)
        {
            Frame_Home HomeFrame;
            if (frame is Frame_Home)
                HomeFrame = ((Frame_Home)frame);

        }

        #region State Members

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void LoadContent(ContentManager Content)
        {
       
        }

        public void Update(Microsoft.Xna.Framework.GameTime time)
        {
        
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
        
        }

        public void UnloadContent(ContentManager Content)
        {
            throw new NotImplementedException();
        }

        public void UnInitialize()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
