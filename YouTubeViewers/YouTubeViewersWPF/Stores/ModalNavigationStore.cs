﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersWPF.ViewModels.Base;

namespace YouTubeViewersWPF.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            { 
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        //only for this assembly
        //if it would was internal protected -  for all into hierarchy
        internal void Close()
        {
            CurrentViewModel = null;
        }

        public bool IsOpen => CurrentViewModel != null;

        //TODO - check here(previous view model)
        public event Action CurrentViewModelChanged;
    }
}
