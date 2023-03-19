﻿using FileExplorerMVVM.Infrastructure.Commands.Base;
using FileExplorerMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Infrastructure.Commands
{
    public class UnPinFavoriteFolderCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public UnPinFavoriteFolderCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
