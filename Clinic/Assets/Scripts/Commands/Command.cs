using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public interface ICommand
{
    ICommand Start();
    ICommand Update();
}
