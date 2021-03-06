﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LessThanOk.GameData;

namespace LessThanOk.Network.Commands.Events
{
    public class NewCommandEventArgs:EventArgs
    {
        public Command Cmd { get { return _command; } }
        public TimeSpan Time { get { return _time; } }
        public Player GamePlayer { get { return _player; } }

        private Player _player;
        private Command _command;
        private TimeSpan _time;

        public NewCommandEventArgs(Command command, TimeSpan time, Player player)
        {
            _player = player;
            _command = command;
            _time = time;
        }

        public NewCommandEventArgs(Command command)
        {
            _command = command;
            _player = null;
        }
    }
}
